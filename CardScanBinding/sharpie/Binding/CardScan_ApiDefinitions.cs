using System;
using AVFoundation;
using CardScan;
using CoreGraphics;
using CoreMedia;
using Foundation;
using UIKit;

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern double CardScanVersionNumber;
	[Field ("CardScanVersionNumber", "__Internal")]
	double CardScanVersionNumber { get; }

	// extern const unsigned char [] CardScanVersionString;
	[Field ("CardScanVersionString", "__Internal")]
	byte[] CardScanVersionString { get; }
}

// @interface CornerView : UIView
[BaseType (typeof(UIView))]
interface CornerView
{
	// -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
	[Export ("initWithFrame:")]
	[DesignatedInitializer]
	IntPtr Constructor (CGRect frame);

	// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
	[Export ("initWithCoder:")]
	[DesignatedInitializer]
	IntPtr Constructor (NSCoder aDecoder);
}

// @interface CreditCard : NSObject
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface CreditCard
{
	// @property (copy, nonatomic) NSString * _Nonnull number;
	[Export ("number")]
	string Number { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable expiryMonth;
	[NullAllowed, Export ("expiryMonth")]
	string ExpiryMonth { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable expiryYear;
	[NullAllowed, Export ("expiryYear")]
	string ExpiryYear { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable name;
	[NullAllowed, Export ("name")]
	string Name { get; set; }

	// -(STPCardParams * _Nonnull)cardParams __attribute__((warn_unused_result));
	[Export ("cardParams")]
	[Verify (MethodToProperty)]
	STPCardParams CardParams { get; }

	// +(instancetype _Nonnull)new __attribute__((deprecated("-init is unavailable")));
	[Static]
	[Export ("new")]
	CreditCard New ();
}

// @protocol ScanDelegate
[Protocol, Model]
interface ScanDelegate
{
	// @required -(void)userDidCancel:(ScanViewController * _Nonnull)scanViewController;
	[Abstract]
	[Export ("userDidCancel:")]
	void UserDidCancel (ScanViewController scanViewController);

	// @required -(void)userDidScanCard:(ScanViewController * _Nonnull)scanViewController creditCard:(CreditCard * _Nonnull)creditCard;
	[Abstract]
	[Export ("userDidScanCard:creditCard:")]
	void UserDidScanCard (ScanViewController scanViewController, CreditCard creditCard);

	// @optional -(void)userDidScanQrCode:(ScanViewController * _Nonnull)scanViewController payload:(NSString * _Nonnull)payload;
	[Export ("userDidScanQrCode:payload:")]
	void UserDidScanQrCode (ScanViewController scanViewController, string payload);

	// @required -(void)userDidSkip:(ScanViewController * _Nonnull)scanViewController;
	[Abstract]
	[Export ("userDidSkip:")]
	void UserDidSkip (ScanViewController scanViewController);
}

// @interface ScanViewController : UIViewController <AVCaptureVideoDataOutputSampleBufferDelegate>
[BaseType (typeof(UIViewController))]
interface ScanViewController : IAVCaptureVideoDataOutputSampleBufferDelegate
{
	// +(ScanViewController * _Nullable)createViewControllerWithDelegate:(id<ScanDelegate> _Nullable)delegate __attribute__((warn_unused_result));
	[Static]
	[Export ("createViewControllerWithDelegate:")]
	[return: NullAllowed]
	ScanViewController CreateViewControllerWithDelegate ([NullAllowed] ScanDelegate @delegate);

	// +(void)configure;
	[Static]
	[Export ("configure")]
	void Configure ();

	// +(BOOL)isCompatible __attribute__((warn_unused_result));
	[Static]
	[Export ("isCompatible")]
	[Verify (MethodToProperty)]
	bool IsCompatible { get; }

	// -(void)viewDidLoad;
	[Export ("viewDidLoad")]
	void ViewDidLoad ();

	// @property (readonly, nonatomic) BOOL shouldAutorotate;
	[Export ("shouldAutorotate")]
	bool ShouldAutorotate { get; }

	// @property (readonly, nonatomic) UIInterfaceOrientationMask supportedInterfaceOrientations;
	[Export ("supportedInterfaceOrientations")]
	UIInterfaceOrientationMask SupportedInterfaceOrientations { get; }

	// @property (readonly, nonatomic) UIStatusBarStyle preferredStatusBarStyle;
	[Export ("preferredStatusBarStyle")]
	UIStatusBarStyle PreferredStatusBarStyle { get; }

	// -(void)viewWillAppear:(BOOL)animated;
	[Export ("viewWillAppear:")]
	void ViewWillAppear (bool animated);

	// -(void)viewWillDisappear:(BOOL)animated;
	[Export ("viewWillDisappear:")]
	void ViewWillDisappear (bool animated);

	// -(void)captureOutput:(AVCaptureOutput * _Nonnull)output didOutputSampleBuffer:(CMSampleBufferRef _Nonnull)sampleBuffer fromConnection:(AVCaptureConnection * _Nonnull)connection;
	[Export ("captureOutput:didOutputSampleBuffer:fromConnection:")]
	unsafe void CaptureOutput (AVCaptureOutput output, CMSampleBufferRef* sampleBuffer, AVCaptureConnection connection);

	// -(instancetype _Nonnull)initWithNibName:(NSString * _Nullable)nibNameOrNil bundle:(NSBundle * _Nullable)nibBundleOrNil __attribute__((objc_designated_initializer));
	[Export ("initWithNibName:bundle:")]
	[DesignatedInitializer]
	IntPtr Constructor ([NullAllowed] string nibNameOrNil, [NullAllowed] NSBundle nibBundleOrNil);

	// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
	[Export ("initWithCoder:")]
	[DesignatedInitializer]
	IntPtr Constructor (NSCoder aDecoder);
}
