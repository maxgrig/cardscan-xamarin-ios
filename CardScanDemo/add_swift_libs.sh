#!/bin/bash
APP_FOLDER="$1"
PLATFORM="$2"

echo "*** Copy Swift libs to ${APP_FOLDER}"

XCODE_PATH=$(xcode-select --print-path)
FRAMEWORKS_FOLDER="${APP_FOLDER}/Frameworks"

case $PLATFORM in
    iPhone|iphone)
        echo "*** Platform is iPhone"
        export SWIFTLIBS_DIR="${XCODE_PATH}/Toolchains/XcodeDefault.xctoolchain/usr/lib/swift/iphoneos"
        break
        ;;
    iPhoneSimulator|iphonesimulator)
        echo "*** Platform is iPhoneSimulator"
        export SWIFTLIBS_DIR="${XCODE_PATH}/Toolchains/XcodeDefault.xctoolchain/usr/lib/swift/iphonesimulator"
        break
        ;;
    *)
        echo "Wrong Platform Type parameter. Exiting..."
        exit 1
        ;;
esac

# Searching for all native frameworks in the app 
# Output example: SomeSDK.framework
echo "*** Searching for native frameworks..." 
for FRAMEWORK in $(find "${FRAMEWORKS_FOLDER}" -type d -iname *.framework | grep -oE '\w+\.framework'); do
    echo "*** ${FRAMEWORK} found"
    frameworkName=$(echo $FRAMEWORK | sed -E 's?.framework??')
    frameworkBinaryPath="${FRAMEWORKS_FOLDER}/${FRAMEWORK}/${frameworkName}"

    # For each native framework we search for swift dependencies using 'otool' 
    # Then copy all neccessary libs from the system folder to both Frameworks and SwiftSupport folders in archive
    echo "*** Checking for Swift dependencies..."
    for swiftLib in $(otool -L -arch arm64 "${frameworkBinaryPath}" | grep rpath | grep -oE '\w+\.dylib'); do
        echo "*** ${swiftLib} found. Copying it to the app"
        cp -pv "${SWIFTLIBS_DIR}/${swiftLib}" "${FRAMEWORKS_FOLDER}/${swiftLib}"
    done   
done

# 'otool' does not show libswiftos.dylib as dependency. But it is required for Swift app.
echo "*** Copying libswiftos.dylib to the app"
libswiftos="libswiftos.dylib"
cp -pv $SWIFTLIBS_DIR/$libswiftos "${FRAMEWORKS_FOLDER}/${libswiftos}"

libswiftSwiftOnoneSupport="libswiftSwiftOnoneSupport.dylib"
cp -pv $SWIFTLIBS_DIR/$libswiftSwiftOnoneSupport "${FRAMEWORKS_FOLDER}/${libswiftSwiftOnoneSupport}"
