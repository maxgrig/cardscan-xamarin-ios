using System;
using Contacts;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using PassKit;
using Stripe;
using UIKit;

// typedef void (^STPVoidBlock)();
delegate void STPVoidBlock ();

// typedef void (^STPErrorBlock)(NSError * _Nullable);
delegate void STPErrorBlock ([NullAllowed] NSError arg0);

// typedef void (^STPJSONResponseCompletionBlock)(NSDictionary * _Nullable, NSError * _Nullable);
delegate void STPJSONResponseCompletionBlock ([NullAllowed] NSDictionary arg0, [NullAllowed] NSError arg1);

// typedef void (^STPTokenCompletionBlock)(STPToken * _Nullable, NSError * _Nullable);
delegate void STPTokenCompletionBlock ([NullAllowed] STPToken arg0, [NullAllowed] NSError arg1);

// typedef void (^STPSourceCompletionBlock)(STPSource * _Nullable, NSError * _Nullable);
delegate void STPSourceCompletionBlock ([NullAllowed] STPSource arg0, [NullAllowed] NSError arg1);

// typedef void (^STPSourceProtocolCompletionBlock)(id<STPSourceProtocol> _Nullable, NSError * _Nullable);
delegate void STPSourceProtocolCompletionBlock ([NullAllowed] STPSourceProtocol arg0, [NullAllowed] NSError arg1);

// typedef void (^STPPaymentIntentCompletionBlock)(STPPaymentIntent * _Nullable, NSError * _Nullable);
delegate void STPPaymentIntentCompletionBlock ([NullAllowed] STPPaymentIntent arg0, [NullAllowed] NSError arg1);

// typedef void (^STPPaymentMethodCompletionBlock)(STPPaymentMethod * _Nullable, NSError * _Nullable);
delegate void STPPaymentMethodCompletionBlock ([NullAllowed] STPPaymentMethod arg0, [NullAllowed] NSError arg1);

// typedef void (^STPShippingMethodsCompletionBlock)(STPShippingStatus, NSError * _Nullable, NSArray<PKShippingMethod *> * _Nullable, PKShippingMethod * _Nullable);
delegate void STPShippingMethodsCompletionBlock (STPShippingStatus arg0, [NullAllowed] NSError arg1, [NullAllowed] PKShippingMethod[] arg2, [NullAllowed] PKShippingMethod arg3);

// typedef void (^STPFileCompletionBlock)(STPFile * _Nullable, NSError * _Nullable);
delegate void STPFileCompletionBlock ([NullAllowed] STPFile arg0, [NullAllowed] NSError arg1);

// typedef void (^STPCustomerCompletionBlock)(STPCustomer * _Nullable, NSError * _Nullable);
delegate void STPCustomerCompletionBlock ([NullAllowed] STPCustomer arg0, [NullAllowed] NSError arg1);

// @protocol STPAPIResponseDecodable <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface STPAPIResponseDecodable
{
	// @required +(instancetype _Nullable)decodedObjectFromAPIResponse:(NSDictionary * _Nullable)response;
	[Static, Abstract]
	[Export ("decodedObjectFromAPIResponse:")]
	[return: NullAllowed]
	STPAPIResponseDecodable DecodedObjectFromAPIResponse ([NullAllowed] NSDictionary response);

	// @required @property (readonly, copy, nonatomic) NSDictionary * _Nonnull allResponseFields;
	[Abstract]
	[Export ("allResponseFields", ArgumentSemantic.Copy)]
	NSDictionary AllResponseFields { get; }
}

// @interface STPFile : NSObject <STPAPIResponseDecodable>
[BaseType (typeof(NSObject))]
interface STPFile : ISTPAPIResponseDecodable
{
	// @property (readonly, nonatomic) NSString * _Nonnull fileId;
	[Export ("fileId")]
	string FileId { get; }

	// @property (readonly, nonatomic) NSDate * _Nonnull created;
	[Export ("created")]
	NSDate Created { get; }

	// @property (readonly, nonatomic) STPFilePurpose purpose;
	[Export ("purpose")]
	STPFilePurpose Purpose { get; }

	// @property (readonly, nonatomic) NSNumber * _Nonnull size;
	[Export ("size")]
	NSNumber Size { get; }

	// @property (readonly, nonatomic) NSString * _Nonnull type;
	[Export ("type")]
	string Type { get; }

	// +(NSString * _Nullable)stringFromPurpose:(STPFilePurpose)purpose;
	[Static]
	[Export ("stringFromPurpose:")]
	[return: NullAllowed]
	string StringFromPurpose (STPFilePurpose purpose);
}

// @interface Stripe : NSObject
[BaseType (typeof(NSObject))]
interface Stripe
{
	// +(NSString * _Nullable)defaultPublishableKey;
	// +(void)setDefaultPublishableKey:(NSString * _Nonnull)publishableKey;
	[Static]
	[NullAllowed, Export ("defaultPublishableKey")]
	[Verify (MethodToProperty)]
	string DefaultPublishableKey { get; set; }
}

// @interface STPAPIClient : NSObject
[BaseType (typeof(NSObject))]
interface STPAPIClient
{
	// +(instancetype _Nonnull)sharedClient;
	[Static]
	[Export ("sharedClient")]
	STPAPIClient SharedClient ();

	// -(instancetype _Nonnull)initWithConfiguration:(STPPaymentConfiguration * _Nonnull)configuration __attribute__((objc_designated_initializer));
	[Export ("initWithConfiguration:")]
	[DesignatedInitializer]
	IntPtr Constructor (STPPaymentConfiguration configuration);

	// -(instancetype _Nonnull)initWithPublishableKey:(NSString * _Nonnull)publishableKey;
	[Export ("initWithPublishableKey:")]
	IntPtr Constructor (string publishableKey);

	// @property (copy, nonatomic) NSString * _Nullable publishableKey;
	[NullAllowed, Export ("publishableKey")]
	string PublishableKey { get; set; }

	// @property (copy, nonatomic) STPPaymentConfiguration * _Nonnull configuration;
	[Export ("configuration", ArgumentSemantic.Copy)]
	STPPaymentConfiguration Configuration { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable stripeAccount;
	[NullAllowed, Export ("stripeAccount")]
	string StripeAccount { get; set; }
}

// @interface BankAccounts (STPAPIClient)
[Category]
[BaseType (typeof(STPAPIClient))]
interface STPAPIClient_BankAccounts
{
	// -(void)createTokenWithBankAccount:(STPBankAccountParams * _Nonnull)bankAccount completion:(STPTokenCompletionBlock _Nullable)completion;
	[Export ("createTokenWithBankAccount:completion:")]
	void CreateTokenWithBankAccount (STPBankAccountParams bankAccount, [NullAllowed] STPTokenCompletionBlock completion);
}

// @interface PII (STPAPIClient)
[Category]
[BaseType (typeof(STPAPIClient))]
interface STPAPIClient_PII
{
	// -(void)createTokenWithPersonalIDNumber:(NSString * _Nonnull)pii completion:(STPTokenCompletionBlock _Nullable)completion;
	[Export ("createTokenWithPersonalIDNumber:completion:")]
	void CreateTokenWithPersonalIDNumber (string pii, [NullAllowed] STPTokenCompletionBlock completion);
}

// @interface ConnectAccounts (STPAPIClient)
[Category]
[BaseType (typeof(STPAPIClient))]
interface STPAPIClient_ConnectAccounts
{
	// -(void)createTokenWithConnectAccount:(STPConnectAccountParams * _Nonnull)account completion:(STPTokenCompletionBlock _Nullable)completion;
	[Export ("createTokenWithConnectAccount:completion:")]
	void CreateTokenWithConnectAccount (STPConnectAccountParams account, [NullAllowed] STPTokenCompletionBlock completion);
}

// @interface Upload (STPAPIClient)
[Category]
[BaseType (typeof(STPAPIClient))]
interface STPAPIClient_Upload
{
	// -(void)uploadImage:(UIImage * _Nonnull)image purpose:(STPFilePurpose)purpose completion:(STPFileCompletionBlock _Nullable)completion;
	[Export ("uploadImage:purpose:completion:")]
	void UploadImage (UIImage image, STPFilePurpose purpose, [NullAllowed] STPFileCompletionBlock completion);
}

// @interface CreditCards (STPAPIClient)
[Category]
[BaseType (typeof(STPAPIClient))]
interface STPAPIClient_CreditCards
{
	// -(void)createTokenWithCard:(STPCardParams * _Nonnull)card completion:(STPTokenCompletionBlock _Nullable)completion;
	[Export ("createTokenWithCard:completion:")]
	void CreateTokenWithCard (STPCardParams card, [NullAllowed] STPTokenCompletionBlock completion);

	// -(void)createTokenForCVCUpdate:(NSString * _Nonnull)cvc completion:(STPTokenCompletionBlock _Nullable)completion;
	[Export ("createTokenForCVCUpdate:completion:")]
	void CreateTokenForCVCUpdate (string cvc, [NullAllowed] STPTokenCompletionBlock completion);
}

// @interface ApplePay (Stripe)
[Category]
[BaseType (typeof(Stripe))]
interface Stripe_ApplePay
{
	// +(BOOL)canSubmitPaymentRequest:(PKPaymentRequest * _Nonnull)paymentRequest;
	[Static]
	[Export ("canSubmitPaymentRequest:")]
	bool CanSubmitPaymentRequest (PKPaymentRequest paymentRequest);

	// +(BOOL)deviceSupportsApplePay;
	[Static]
	[Export ("deviceSupportsApplePay")]
	[Verify (MethodToProperty)]
	bool DeviceSupportsApplePay { get; }

	// +(PKPaymentRequest * _Nonnull)paymentRequestWithMerchantIdentifier:(NSString * _Nonnull)merchantIdentifier __attribute__((deprecated("")));
	[Static]
	[Export ("paymentRequestWithMerchantIdentifier:")]
	PKPaymentRequest PaymentRequestWithMerchantIdentifier (string merchantIdentifier);

	// +(PKPaymentRequest * _Nonnull)paymentRequestWithMerchantIdentifier:(NSString * _Nonnull)merchantIdentifier country:(NSString * _Nonnull)countryCode currency:(NSString * _Nonnull)currencyCode;
	[Static]
	[Export ("paymentRequestWithMerchantIdentifier:country:currency:")]
	PKPaymentRequest PaymentRequestWithMerchantIdentifier (string merchantIdentifier, string countryCode, string currencyCode);

	// @property (getter = isJCBPaymentNetworkSupported, nonatomic, class) BOOL JCBPaymentNetworkSupported;
	[Static]
	[Export ("JCBPaymentNetworkSupported")]
	bool JCBPaymentNetworkSupported { [Bind ("isJCBPaymentNetworkSupported")] get; set; }
}

// @interface Sources (STPAPIClient)
[Category]
[BaseType (typeof(STPAPIClient))]
interface STPAPIClient_Sources
{
	// -(void)createSourceWithParams:(STPSourceParams * _Nonnull)params completion:(STPSourceCompletionBlock _Nonnull)completion;
	[Export ("createSourceWithParams:completion:")]
	void CreateSourceWithParams (STPSourceParams @params, STPSourceCompletionBlock completion);

	// -(void)retrieveSourceWithId:(NSString * _Nonnull)identifier clientSecret:(NSString * _Nonnull)secret completion:(STPSourceCompletionBlock _Nonnull)completion;
	[Export ("retrieveSourceWithId:clientSecret:completion:")]
	void RetrieveSourceWithId (string identifier, string secret, STPSourceCompletionBlock completion);

	// -(void)startPollingSourceWithId:(NSString * _Nonnull)identifier clientSecret:(NSString * _Nonnull)secret timeout:(NSTimeInterval)timeout completion:(STPSourceCompletionBlock _Nonnull)completion __attribute__((deprecated("You should poll your own backend to update based on source status change webhook events it may receive."))) __attribute__((availability(ios_app_extension, unavailable))) __attribute__((availability(macos_app_extension, unavailable)));
	[Unavailable (PlatformName.iOSAppExtension)]
	[Unavailable (PlatformName.MacOSXAppExtension)]
	[Export ("startPollingSourceWithId:clientSecret:timeout:completion:")]
	void StartPollingSourceWithId (string identifier, string secret, double timeout, STPSourceCompletionBlock completion);

	// -(void)stopPollingSourceWithId:(NSString * _Nonnull)identifier __attribute__((deprecated(""))) __attribute__((availability(ios_app_extension, unavailable))) __attribute__((availability(macos_app_extension, unavailable)));
	[Unavailable (PlatformName.iOSAppExtension)]
	[Unavailable (PlatformName.MacOSXAppExtension)]
	[Export ("stopPollingSourceWithId:")]
	void StopPollingSourceWithId (string identifier);
}

// @interface PaymentIntents (STPAPIClient)
[Category]
[BaseType (typeof(STPAPIClient))]
interface STPAPIClient_PaymentIntents
{
	// -(void)retrievePaymentIntentWithClientSecret:(NSString * _Nonnull)secret completion:(STPPaymentIntentCompletionBlock _Nonnull)completion;
	[Export ("retrievePaymentIntentWithClientSecret:completion:")]
	void RetrievePaymentIntentWithClientSecret (string secret, STPPaymentIntentCompletionBlock completion);

	// -(void)confirmPaymentIntentWithParams:(STPPaymentIntentParams * _Nonnull)paymentIntentParams completion:(STPPaymentIntentCompletionBlock _Nonnull)completion;
	[Export ("confirmPaymentIntentWithParams:completion:")]
	void ConfirmPaymentIntentWithParams (STPPaymentIntentParams paymentIntentParams, STPPaymentIntentCompletionBlock completion);
}

// @interface PaymentMethods (STPAPIClient)
[Category]
[BaseType (typeof(STPAPIClient))]
interface STPAPIClient_PaymentMethods
{
	// -(void)createPaymentMethodWithParams:(STPPaymentMethodParams * _Nonnull)paymentMethodParams completion:(STPPaymentMethodCompletionBlock _Nonnull)completion;
	[Export ("createPaymentMethodWithParams:completion:")]
	void CreatePaymentMethodWithParams (STPPaymentMethodParams paymentMethodParams, STPPaymentMethodCompletionBlock completion);
}

// @interface STPURLCallbackHandlerAdditions (Stripe)
[Category]
[BaseType (typeof(Stripe))]
interface Stripe_STPURLCallbackHandlerAdditions
{
	// +(BOOL)handleStripeURLCallbackWithURL:(NSURL * _Nonnull)url;
	[Static]
	[Export ("handleStripeURLCallbackWithURL:")]
	bool HandleStripeURLCallbackWithURL (NSUrl url);
}

// @protocol STPFormEncodable <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface STPFormEncodable
{
	// @required +(NSString * _Nullable)rootObjectName;
	[Static, Abstract]
	[NullAllowed, Export ("rootObjectName")]
	[Verify (MethodToProperty)]
	string RootObjectName { get; }

	// @required +(NSDictionary * _Nonnull)propertyNamesToFormFieldNamesMapping;
	[Static, Abstract]
	[Export ("propertyNamesToFormFieldNamesMapping")]
	[Verify (MethodToProperty)]
	NSDictionary PropertyNamesToFormFieldNamesMapping { get; }

	// @required @property (readwrite, copy, nonatomic) NSDictionary * _Nonnull additionalAPIParameters;
	[Abstract]
	[Export ("additionalAPIParameters", ArgumentSemantic.Copy)]
	NSDictionary AdditionalAPIParameters { get; set; }
}

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern const STPContactField _Nonnull STPContactFieldPostalAddress;
	[Field ("STPContactFieldPostalAddress", "__Internal")]
	NSString STPContactFieldPostalAddress { get; }

	// extern const STPContactField _Nonnull STPContactFieldEmailAddress;
	[Field ("STPContactFieldEmailAddress", "__Internal")]
	NSString STPContactFieldEmailAddress { get; }

	// extern const STPContactField _Nonnull STPContactFieldPhoneNumber;
	[Field ("STPContactFieldPhoneNumber", "__Internal")]
	NSString STPContactFieldPhoneNumber { get; }

	// extern const STPContactField _Nonnull STPContactFieldName;
	[Field ("STPContactFieldName", "__Internal")]
	NSString STPContactFieldName { get; }
}

// @interface STPAddress : NSObject <STPAPIResponseDecodable, STPFormEncodable, NSCopying>
[BaseType (typeof(NSObject))]
interface STPAddress : ISTPAPIResponseDecodable, ISTPFormEncodable, INSCopying
{
	// @property (copy, nonatomic) NSString * _Nullable name;
	[NullAllowed, Export ("name")]
	string Name { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable line1;
	[NullAllowed, Export ("line1")]
	string Line1 { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable line2;
	[NullAllowed, Export ("line2")]
	string Line2 { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable city;
	[NullAllowed, Export ("city")]
	string City { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable state;
	[NullAllowed, Export ("state")]
	string State { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable postalCode;
	[NullAllowed, Export ("postalCode")]
	string PostalCode { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable country;
	[NullAllowed, Export ("country")]
	string Country { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable phone;
	[NullAllowed, Export ("phone")]
	string Phone { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable email;
	[NullAllowed, Export ("email")]
	string Email { get; set; }

	// +(NSDictionary * _Nullable)shippingInfoForChargeWithAddress:(STPAddress * _Nullable)address shippingMethod:(PKShippingMethod * _Nullable)method;
	[Static]
	[Export ("shippingInfoForChargeWithAddress:shippingMethod:")]
	[return: NullAllowed]
	NSDictionary ShippingInfoForChargeWithAddress ([NullAllowed] STPAddress address, [NullAllowed] PKShippingMethod method);

	// -(instancetype _Nonnull)initWithPKContact:(PKContact * _Nonnull)contact;
	[Export ("initWithPKContact:")]
	IntPtr Constructor (PKContact contact);

	// -(PKContact * _Nonnull)PKContactValue;
	[Export ("PKContactValue")]
	[Verify (MethodToProperty)]
	PKContact PKContactValue { get; }

	// -(instancetype _Nonnull)initWithCNContact:(CNContact * _Nonnull)contact;
	[Export ("initWithCNContact:")]
	IntPtr Constructor (CNContact contact);

	// -(BOOL)containsRequiredFields:(STPBillingAddressFields)requiredFields;
	[Export ("containsRequiredFields:")]
	bool ContainsRequiredFields (STPBillingAddressFields requiredFields);

	// -(BOOL)containsContentForBillingAddressFields:(STPBillingAddressFields)desiredFields;
	[Export ("containsContentForBillingAddressFields:")]
	bool ContainsContentForBillingAddressFields (STPBillingAddressFields desiredFields);

	// -(BOOL)containsRequiredShippingAddressFields:(NSSet<STPContactField> * _Nullable)requiredFields;
	[Export ("containsRequiredShippingAddressFields:")]
	bool ContainsRequiredShippingAddressFields ([NullAllowed] NSSet<NSString> requiredFields);

	// -(BOOL)containsContentForShippingAddressFields:(NSSet<STPContactField> * _Nullable)desiredFields;
	[Export ("containsContentForShippingAddressFields:")]
	bool ContainsContentForShippingAddressFields ([NullAllowed] NSSet<NSString> desiredFields);

	// +(PKAddressField)applePayAddressFieldsFromBillingAddressFields:(STPBillingAddressFields)billingAddressFields;
	[Static]
	[Export ("applePayAddressFieldsFromBillingAddressFields:")]
	PKAddressField ApplePayAddressFieldsFromBillingAddressFields (STPBillingAddressFields billingAddressFields);

	// +(PKAddressField)pkAddressFieldsFromStripeContactFields:(NSSet<STPContactField> * _Nullable)contactFields;
	[Static]
	[Export ("pkAddressFieldsFromStripeContactFields:")]
	PKAddressField PkAddressFieldsFromStripeContactFields ([NullAllowed] NSSet<NSString> contactFields);

	// +(NSSet<PKContactField> * _Nullable)pkContactFieldsFromStripeContactFields:(NSSet<STPContactField> * _Nullable)contactFields __attribute__((availability(ios, introduced=11.0)));
	[iOS (11,0)]
	[Static]
	[Export ("pkContactFieldsFromStripeContactFields:")]
	[return: NullAllowed]
	NSSet<NSString> PkContactFieldsFromStripeContactFields ([NullAllowed] NSSet<NSString> contactFields);
}

// @interface STPCardParams : NSObject <STPFormEncodable, NSCopying>
[BaseType (typeof(NSObject))]
interface STPCardParams : ISTPFormEncodable, INSCopying
{
	// @property (copy, nonatomic) NSString * _Nullable number;
	[NullAllowed, Export ("number")]
	string Number { get; set; }

	// -(NSString * _Nullable)last4;
	[NullAllowed, Export ("last4")]
	[Verify (MethodToProperty)]
	string Last4 { get; }

	// @property (nonatomic) NSUInteger expMonth;
	[Export ("expMonth")]
	nuint ExpMonth { get; set; }

	// @property (nonatomic) NSUInteger expYear;
	[Export ("expYear")]
	nuint ExpYear { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable cvc;
	[NullAllowed, Export ("cvc")]
	string Cvc { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable name;
	[NullAllowed, Export ("name")]
	string Name { get; set; }

	// @property (nonatomic, strong) STPAddress * _Nonnull address;
	[Export ("address", ArgumentSemantic.Strong)]
	STPAddress Address { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable currency;
	[NullAllowed, Export ("currency")]
	string Currency { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable addressLine1 __attribute__((deprecated("Use address.line1")));
	[NullAllowed, Export ("addressLine1")]
	string AddressLine1 { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable addressLine2 __attribute__((deprecated("Use address.line2")));
	[NullAllowed, Export ("addressLine2")]
	string AddressLine2 { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable addressCity __attribute__((deprecated("Use address.city")));
	[NullAllowed, Export ("addressCity")]
	string AddressCity { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable addressState __attribute__((deprecated("Use address.state")));
	[NullAllowed, Export ("addressState")]
	string AddressState { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable addressZip __attribute__((deprecated("Use address.postalCode")));
	[NullAllowed, Export ("addressZip")]
	string AddressZip { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable addressCountry __attribute__((deprecated("Use address.country")));
	[NullAllowed, Export ("addressCountry")]
	string AddressCountry { get; set; }
}

// @interface STPCoreViewController : UIViewController
[BaseType (typeof(UIViewController))]
interface STPCoreViewController
{
	// -(instancetype _Nonnull)initWithTheme:(STPTheme * _Nonnull)theme __attribute__((objc_designated_initializer));
	[Export ("initWithTheme:")]
	[DesignatedInitializer]
	IntPtr Constructor (STPTheme theme);

	// -(instancetype _Nonnull)initWithNibName:(NSString * _Nullable)nibNameOrNil bundle:(NSBundle * _Nullable)nibBundleOrNil __attribute__((objc_designated_initializer));
	[Export ("initWithNibName:bundle:")]
	[DesignatedInitializer]
	IntPtr Constructor ([NullAllowed] string nibNameOrNil, [NullAllowed] NSBundle nibBundleOrNil);

	// -(instancetype _Nullable)initWithCoder:(NSCoder * _Nonnull)aDecoder __attribute__((objc_designated_initializer));
	[Export ("initWithCoder:")]
	[DesignatedInitializer]
	IntPtr Constructor (NSCoder aDecoder);
}

// @interface STPCoreScrollViewController : STPCoreViewController
[BaseType (typeof(STPCoreViewController))]
interface STPCoreScrollViewController
{
}

// @interface STPCoreTableViewController : STPCoreScrollViewController
[BaseType (typeof(STPCoreScrollViewController))]
interface STPCoreTableViewController
{
}

// @protocol STPSourceProtocol <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface STPSourceProtocol
{
	// @required @property (readonly, nonatomic) NSString * _Nonnull stripeID;
	[Abstract]
	[Export ("stripeID")]
	string StripeID { get; }
}

// @interface STPCustomer : NSObject <STPAPIResponseDecodable>
[BaseType (typeof(NSObject))]
interface STPCustomer : ISTPAPIResponseDecodable
{
	// +(instancetype _Nonnull)customerWithStripeID:(NSString * _Nonnull)stripeID defaultSource:(id<STPSourceProtocol> _Nullable)defaultSource sources:(NSArray<id<STPSourceProtocol>> * _Nonnull)sources;
	[Static]
	[Export ("customerWithStripeID:defaultSource:sources:")]
	STPCustomer CustomerWithStripeID (string stripeID, [NullAllowed] STPSourceProtocol defaultSource, STPSourceProtocol[] sources);

	// @property (readonly, copy, nonatomic) NSString * _Nonnull stripeID;
	[Export ("stripeID")]
	string StripeID { get; }

	// @property (readonly, nonatomic) id<STPSourceProtocol> _Nullable defaultSource;
	[NullAllowed, Export ("defaultSource")]
	STPSourceProtocol DefaultSource { get; }

	// @property (readonly, nonatomic) NSArray<id<STPSourceProtocol>> * _Nonnull sources;
	[Export ("sources")]
	STPSourceProtocol[] Sources { get; }

	// @property (readonly, nonatomic) STPAddress * _Nullable shippingAddress;
	[NullAllowed, Export ("shippingAddress")]
	STPAddress ShippingAddress { get; }
}

// @interface STPCustomerDeserializer : NSObject
[BaseType (typeof(NSObject))]
interface STPCustomerDeserializer
{
	// -(instancetype _Nonnull)initWithData:(NSData * _Nullable)data urlResponse:(NSURLResponse * _Nullable)urlResponse error:(NSError * _Nullable)error;
	[Export ("initWithData:urlResponse:error:")]
	IntPtr Constructor ([NullAllowed] NSData data, [NullAllowed] NSUrlResponse urlResponse, [NullAllowed] NSError error);

	// -(instancetype _Nonnull)initWithJSONResponse:(id _Nonnull)json;
	[Export ("initWithJSONResponse:")]
	IntPtr Constructor (NSObject json);

	// @property (readonly, nonatomic) STPCustomer * _Nullable customer;
	[NullAllowed, Export ("customer")]
	STPCustomer Customer { get; }

	// @property (readonly, nonatomic) NSError * _Nullable error;
	[NullAllowed, Export ("error")]
	NSError Error { get; }
}

// @protocol STPBackendAPIAdapter <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface STPBackendAPIAdapter
{
	// @required -(void)retrieveCustomer:(STPCustomerCompletionBlock _Nullable)completion;
	[Abstract]
	[Export ("retrieveCustomer:")]
	void RetrieveCustomer ([NullAllowed] STPCustomerCompletionBlock completion);

	// @required -(void)attachSourceToCustomer:(id<STPSourceProtocol> _Nonnull)source completion:(STPErrorBlock _Nonnull)completion;
	[Abstract]
	[Export ("attachSourceToCustomer:completion:")]
	void AttachSourceToCustomer (STPSourceProtocol source, STPErrorBlock completion);

	// @required -(void)selectDefaultCustomerSource:(id<STPSourceProtocol> _Nonnull)source completion:(STPErrorBlock _Nonnull)completion;
	[Abstract]
	[Export ("selectDefaultCustomerSource:completion:")]
	void SelectDefaultCustomerSource (STPSourceProtocol source, STPErrorBlock completion);

	// @optional -(void)detachSourceFromCustomer:(id<STPSourceProtocol> _Nonnull)source completion:(STPErrorBlock _Nullable)completion;
	[Export ("detachSourceFromCustomer:completion:")]
	void DetachSourceFromCustomer (STPSourceProtocol source, [NullAllowed] STPErrorBlock completion);

	// @optional -(void)updateCustomerWithShippingAddress:(STPAddress * _Nonnull)shipping completion:(STPErrorBlock _Nullable)completion;
	[Export ("updateCustomerWithShippingAddress:completion:")]
	void UpdateCustomerWithShippingAddress (STPAddress shipping, [NullAllowed] STPErrorBlock completion);
}

// @protocol STPPaymentOption <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface STPPaymentOption
{
	// @required @property (readonly, nonatomic, strong) UIImage * _Nonnull image;
	[Abstract]
	[Export ("image", ArgumentSemantic.Strong)]
	UIImage Image { get; }

	// @required @property (readonly, nonatomic, strong) UIImage * _Nonnull templateImage;
	[Abstract]
	[Export ("templateImage", ArgumentSemantic.Strong)]
	UIImage TemplateImage { get; }

	// @required @property (readonly, nonatomic, strong) NSString * _Nonnull label;
	[Abstract]
	[Export ("label", ArgumentSemantic.Strong)]
	string Label { get; }
}

// @interface STPTheme : NSObject <NSCopying>
[BaseType (typeof(NSObject))]
interface STPTheme : INSCopying
{
	// +(STPTheme * _Nonnull)defaultTheme;
	[Static]
	[Export ("defaultTheme")]
	[Verify (MethodToProperty)]
	STPTheme DefaultTheme { get; }

	// @property (copy, nonatomic) UIColor * _Null_unspecified primaryBackgroundColor;
	[Export ("primaryBackgroundColor", ArgumentSemantic.Copy)]
	UIColor PrimaryBackgroundColor { get; set; }

	// @property (copy, nonatomic) UIColor * _Null_unspecified secondaryBackgroundColor;
	[Export ("secondaryBackgroundColor", ArgumentSemantic.Copy)]
	UIColor SecondaryBackgroundColor { get; set; }

	// @property (readonly, nonatomic) UIColor * _Nonnull tertiaryBackgroundColor;
	[Export ("tertiaryBackgroundColor")]
	UIColor TertiaryBackgroundColor { get; }

	// @property (readonly, nonatomic) UIColor * _Nonnull quaternaryBackgroundColor;
	[Export ("quaternaryBackgroundColor")]
	UIColor QuaternaryBackgroundColor { get; }

	// @property (copy, nonatomic) UIColor * _Null_unspecified primaryForegroundColor;
	[Export ("primaryForegroundColor", ArgumentSemantic.Copy)]
	UIColor PrimaryForegroundColor { get; set; }

	// @property (copy, nonatomic) UIColor * _Null_unspecified secondaryForegroundColor;
	[Export ("secondaryForegroundColor", ArgumentSemantic.Copy)]
	UIColor SecondaryForegroundColor { get; set; }

	// @property (readonly, nonatomic) UIColor * _Nonnull tertiaryForegroundColor;
	[Export ("tertiaryForegroundColor")]
	UIColor TertiaryForegroundColor { get; }

	// @property (copy, nonatomic) UIColor * _Null_unspecified accentColor;
	[Export ("accentColor", ArgumentSemantic.Copy)]
	UIColor AccentColor { get; set; }

	// @property (copy, nonatomic) UIColor * _Null_unspecified errorColor;
	[Export ("errorColor", ArgumentSemantic.Copy)]
	UIColor ErrorColor { get; set; }

	// @property (copy, nonatomic) UIFont * _Null_unspecified font;
	[Export ("font", ArgumentSemantic.Copy)]
	UIFont Font { get; set; }

	// @property (copy, nonatomic) UIFont * _Null_unspecified emphasisFont;
	[Export ("emphasisFont", ArgumentSemantic.Copy)]
	UIFont EmphasisFont { get; set; }

	// @property (nonatomic) UIBarStyle barStyle;
	[Export ("barStyle", ArgumentSemantic.Assign)]
	UIBarStyle BarStyle { get; set; }

	// @property (nonatomic) BOOL translucentNavigationBar;
	[Export ("translucentNavigationBar")]
	bool TranslucentNavigationBar { get; set; }

	// @property (readonly, nonatomic) UIFont * _Nonnull smallFont;
	[Export ("smallFont")]
	UIFont SmallFont { get; }

	// @property (readonly, nonatomic) UIFont * _Nonnull largeFont;
	[Export ("largeFont")]
	UIFont LargeFont { get; }
}

// @interface STPPaymentConfiguration : NSObject <NSCopying>
[BaseType (typeof(NSObject))]
interface STPPaymentConfiguration : INSCopying
{
	// +(instancetype _Nonnull)sharedConfiguration;
	[Static]
	[Export ("sharedConfiguration")]
	STPPaymentConfiguration SharedConfiguration ();

	// @property (readwrite, copy, nonatomic) NSString * _Nonnull publishableKey;
	[Export ("publishableKey")]
	string PublishableKey { get; set; }

	// @property (assign, readwrite, nonatomic) STPPaymentOptionType additionalPaymentOptions;
	[Export ("additionalPaymentOptions", ArgumentSemantic.Assign)]
	STPPaymentOptionType AdditionalPaymentOptions { get; set; }

	// @property (assign, readwrite, nonatomic) STPBillingAddressFields requiredBillingAddressFields;
	[Export ("requiredBillingAddressFields", ArgumentSemantic.Assign)]
	STPBillingAddressFields RequiredBillingAddressFields { get; set; }

	// @property (readwrite, copy, nonatomic) NSSet<STPContactField> * _Nullable requiredShippingAddressFields;
	[NullAllowed, Export ("requiredShippingAddressFields", ArgumentSemantic.Copy)]
	NSSet<NSString> RequiredShippingAddressFields { get; set; }

	// @property (assign, readwrite, nonatomic) BOOL verifyPrefilledShippingAddress;
	[Export ("verifyPrefilledShippingAddress")]
	bool VerifyPrefilledShippingAddress { get; set; }

	// @property (assign, readwrite, nonatomic) STPShippingType shippingType;
	[Export ("shippingType", ArgumentSemantic.Assign)]
	STPShippingType ShippingType { get; set; }

	// @property (readwrite, copy, nonatomic) NSString * _Nonnull companyName;
	[Export ("companyName")]
	string CompanyName { get; set; }

	// @property (readwrite, copy, nonatomic) NSString * _Nullable appleMerchantIdentifier;
	[NullAllowed, Export ("appleMerchantIdentifier")]
	string AppleMerchantIdentifier { get; set; }

	// @property (assign, readwrite, nonatomic) BOOL canDeletePaymentOptions;
	[Export ("canDeletePaymentOptions")]
	bool CanDeletePaymentOptions { get; set; }

	// @property (assign, nonatomic) BOOL createCardSources;
	[Export ("createCardSources")]
	bool CreateCardSources { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable stripeAccount;
	[NullAllowed, Export ("stripeAccount")]
	string StripeAccount { get; set; }
}

// @interface STPUserInformation : NSObject <NSCopying>
[BaseType (typeof(NSObject))]
interface STPUserInformation : INSCopying
{
	// @property (nonatomic, strong) STPAddress * _Nullable billingAddress;
	[NullAllowed, Export ("billingAddress", ArgumentSemantic.Strong)]
	STPAddress BillingAddress { get; set; }

	// @property (nonatomic, strong) STPAddress * _Nullable shippingAddress;
	[NullAllowed, Export ("shippingAddress", ArgumentSemantic.Strong)]
	STPAddress ShippingAddress { get; set; }
}

// @interface STPAddCardViewController : STPCoreTableViewController
[BaseType (typeof(STPCoreTableViewController))]
interface STPAddCardViewController
{
	// -(instancetype _Nonnull)initWithConfiguration:(STPPaymentConfiguration * _Nonnull)configuration theme:(STPTheme * _Nonnull)theme;
	[Export ("initWithConfiguration:theme:")]
	IntPtr Constructor (STPPaymentConfiguration configuration, STPTheme theme);

	[Wrap ("WeakDelegate")]
	[NullAllowed]
	STPAddCardViewControllerDelegate Delegate { get; set; }

	// @property (nonatomic, weak) id<STPAddCardViewControllerDelegate> _Nullable delegate;
	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
	NSObject WeakDelegate { get; set; }

	// @property (nonatomic, strong) STPUserInformation * _Nullable prefilledInformation;
	[NullAllowed, Export ("prefilledInformation", ArgumentSemantic.Strong)]
	STPUserInformation PrefilledInformation { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable managedAccountCurrency;
	[NullAllowed, Export ("managedAccountCurrency")]
	string ManagedAccountCurrency { get; set; }

	// @property (nonatomic, strong) UIView * _Nullable customFooterView;
	[NullAllowed, Export ("customFooterView", ArgumentSemantic.Strong)]
	UIView CustomFooterView { get; set; }
}

// @protocol STPAddCardViewControllerDelegate <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface STPAddCardViewControllerDelegate
{
	// @required -(void)addCardViewControllerDidCancel:(STPAddCardViewController * _Nonnull)addCardViewController;
	[Abstract]
	[Export ("addCardViewControllerDidCancel:")]
	void AddCardViewControllerDidCancel (STPAddCardViewController addCardViewController);

	// @optional -(void)addCardViewController:(STPAddCardViewController * _Nonnull)addCardViewController didCreateToken:(STPToken * _Nonnull)token completion:(STPErrorBlock _Nonnull)completion;
	[Export ("addCardViewController:didCreateToken:completion:")]
	void AddCardViewController (STPAddCardViewController addCardViewController, STPToken token, STPErrorBlock completion);

	// @optional -(void)addCardViewController:(STPAddCardViewController * _Nonnull)addCardViewController didCreateSource:(STPSource * _Nonnull)source completion:(STPErrorBlock _Nonnull)completion;
	[Export ("addCardViewController:didCreateSource:completion:")]
	void AddCardViewController (STPAddCardViewController addCardViewController, STPSource source, STPErrorBlock completion);
}

// @interface ApplePay (STPAPIClient)
[Category]
[BaseType (typeof(STPAPIClient))]
interface STPAPIClient_ApplePay
{
	// -(void)createTokenWithPayment:(PKPayment * _Nonnull)payment completion:(STPTokenCompletionBlock _Nonnull)completion;
	[Export ("createTokenWithPayment:completion:")]
	void CreateTokenWithPayment (PKPayment payment, STPTokenCompletionBlock completion);

	// -(void)createSourceWithPayment:(PKPayment * _Nonnull)payment completion:(STPSourceCompletionBlock _Nonnull)completion;
	[Export ("createSourceWithPayment:completion:")]
	void CreateSourceWithPayment (PKPayment payment, STPSourceCompletionBlock completion);
}

// @interface STPApplePayPaymentOption : NSObject <STPPaymentOption>
[BaseType (typeof(NSObject))]
interface STPApplePayPaymentOption : ISTPPaymentOption
{
}

// @interface STPBankAccountParams : NSObject <STPFormEncodable>
[BaseType (typeof(NSObject))]
interface STPBankAccountParams : ISTPFormEncodable
{
	// @property (copy, nonatomic) NSString * _Nullable accountNumber;
	[NullAllowed, Export ("accountNumber")]
	string AccountNumber { get; set; }

	// @property (readonly, nonatomic) NSString * _Nullable last4;
	[NullAllowed, Export ("last4")]
	string Last4 { get; }

	// @property (copy, nonatomic) NSString * _Nullable routingNumber;
	[NullAllowed, Export ("routingNumber")]
	string RoutingNumber { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable country;
	[NullAllowed, Export ("country")]
	string Country { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable currency;
	[NullAllowed, Export ("currency")]
	string Currency { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable accountHolderName;
	[NullAllowed, Export ("accountHolderName")]
	string AccountHolderName { get; set; }

	// @property (assign, nonatomic) STPBankAccountHolderType accountHolderType;
	[Export ("accountHolderType", ArgumentSemantic.Assign)]
	STPBankAccountHolderType AccountHolderType { get; set; }
}

// @interface STPBankAccount : NSObject <STPAPIResponseDecodable, STPSourceProtocol>
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface STPBankAccount : ISTPAPIResponseDecodable, ISTPSourceProtocol
{
	// @property (readonly, nonatomic) NSString * _Nullable routingNumber;
	[NullAllowed, Export ("routingNumber")]
	string RoutingNumber { get; }

	// @property (readonly, nonatomic) NSString * _Nonnull country;
	[Export ("country")]
	string Country { get; }

	// @property (readonly, nonatomic) NSString * _Nonnull currency;
	[Export ("currency")]
	string Currency { get; }

	// @property (readonly, nonatomic) NSString * _Nonnull last4;
	[Export ("last4")]
	string Last4 { get; }

	// @property (readonly, nonatomic) NSString * _Nonnull bankName;
	[Export ("bankName")]
	string BankName { get; }

	// @property (readonly, nonatomic) NSString * _Nullable accountHolderName;
	[NullAllowed, Export ("accountHolderName")]
	string AccountHolderName { get; }

	// @property (readonly, nonatomic) STPBankAccountHolderType accountHolderType;
	[Export ("accountHolderType")]
	STPBankAccountHolderType AccountHolderType { get; }

	// @property (readonly, nonatomic) NSString * _Nullable fingerprint;
	[NullAllowed, Export ("fingerprint")]
	string Fingerprint { get; }

	// @property (readonly, copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nullable metadata;
	[NullAllowed, Export ("metadata", ArgumentSemantic.Copy)]
	NSDictionary<NSString, NSString> Metadata { get; }

	// @property (readonly, nonatomic) STPBankAccountStatus status;
	[Export ("status")]
	STPBankAccountStatus Status { get; }

	// @property (readonly, nonatomic) NSString * _Nonnull bankAccountId __attribute__((deprecated("Use stripeID (defined in STPSourceProtocol)")));
	[Export ("bankAccountId")]
	string BankAccountId { get; }
}

// @interface STPCard : NSObject <STPAPIResponseDecodable, STPPaymentOption, STPSourceProtocol>
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface STPCard : ISTPAPIResponseDecodable, ISTPPaymentOption, ISTPSourceProtocol
{
	// @property (readonly, nonatomic) NSString * _Nonnull last4;
	[Export ("last4")]
	string Last4 { get; }

	// @property (readonly, nonatomic) NSString * _Nullable dynamicLast4;
	[NullAllowed, Export ("dynamicLast4")]
	string DynamicLast4 { get; }

	// @property (readonly, nonatomic) BOOL isApplePayCard;
	[Export ("isApplePayCard")]
	bool IsApplePayCard { get; }

	// @property (readonly, nonatomic) NSUInteger expMonth;
	[Export ("expMonth")]
	nuint ExpMonth { get; }

	// @property (readonly, nonatomic) NSUInteger expYear;
	[Export ("expYear")]
	nuint ExpYear { get; }

	// @property (readonly, nonatomic) NSString * _Nullable name;
	[NullAllowed, Export ("name")]
	string Name { get; }

	// @property (readonly, nonatomic) STPAddress * _Nonnull address;
	[Export ("address")]
	STPAddress Address { get; }

	// @property (readonly, nonatomic) STPCardBrand brand;
	[Export ("brand")]
	STPCardBrand Brand { get; }

	// @property (readonly, nonatomic) STPCardFundingType funding;
	[Export ("funding")]
	STPCardFundingType Funding { get; }

	// @property (readonly, nonatomic) NSString * _Nullable country;
	[NullAllowed, Export ("country")]
	string Country { get; }

	// @property (readonly, nonatomic) NSString * _Nullable currency;
	[NullAllowed, Export ("currency")]
	string Currency { get; }

	// @property (readonly, copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nullable metadata;
	[NullAllowed, Export ("metadata", ArgumentSemantic.Copy)]
	NSDictionary<NSString, NSString> Metadata { get; }

	// +(NSString * _Nonnull)stringFromBrand:(STPCardBrand)brand;
	[Static]
	[Export ("stringFromBrand:")]
	string StringFromBrand (STPCardBrand brand);

	// +(STPCardBrand)brandFromString:(NSString * _Nonnull)string;
	[Static]
	[Export ("brandFromString:")]
	STPCardBrand BrandFromString (string @string);

	// @property (readonly, nonatomic) NSString * _Nonnull cardId __attribute__((deprecated("Use stripeID (defined in STPSourceProtocol)")));
	[Export ("cardId")]
	string CardId { get; }

	// @property (readonly, nonatomic) NSString * _Nullable addressLine1 __attribute__((deprecated("Use address.line1")));
	[NullAllowed, Export ("addressLine1")]
	string AddressLine1 { get; }

	// @property (readonly, nonatomic) NSString * _Nullable addressLine2 __attribute__((deprecated("Use address.line2")));
	[NullAllowed, Export ("addressLine2")]
	string AddressLine2 { get; }

	// @property (readonly, nonatomic) NSString * _Nullable addressCity __attribute__((deprecated("Use address.city")));
	[NullAllowed, Export ("addressCity")]
	string AddressCity { get; }

	// @property (readonly, nonatomic) NSString * _Nullable addressState __attribute__((deprecated("Use address.state")));
	[NullAllowed, Export ("addressState")]
	string AddressState { get; }

	// @property (readonly, nonatomic) NSString * _Nullable addressZip __attribute__((deprecated("Use address.postalCode")));
	[NullAllowed, Export ("addressZip")]
	string AddressZip { get; }

	// @property (readonly, nonatomic) NSString * _Nullable addressCountry __attribute__((deprecated("Use address.country")));
	[NullAllowed, Export ("addressCountry")]
	string AddressCountry { get; }

	// -(instancetype _Nonnull)initWithID:(NSString * _Nonnull)cardID brand:(STPCardBrand)brand last4:(NSString * _Nonnull)last4 expMonth:(NSUInteger)expMonth expYear:(NSUInteger)expYear funding:(STPCardFundingType)funding __attribute__((deprecated("You cannot directly instantiate an STPCard. You should only use one that has been returned from an STPAPIClient callback.")));
	[Export ("initWithID:brand:last4:expMonth:expYear:funding:")]
	IntPtr Constructor (string cardID, STPCardBrand brand, string last4, nuint expMonth, nuint expYear, STPCardFundingType funding);

	// +(STPCardFundingType)fundingFromString:(NSString * _Nonnull)string __attribute__((deprecated("")));
	[Static]
	[Export ("fundingFromString:")]
	STPCardFundingType FundingFromString (string @string);
}

// @interface STPCardValidator : NSObject
[BaseType (typeof(NSObject))]
interface STPCardValidator
{
	// +(NSString * _Nonnull)sanitizedNumericStringForString:(NSString * _Nonnull)string;
	[Static]
	[Export ("sanitizedNumericStringForString:")]
	string SanitizedNumericStringForString (string @string);

	// +(BOOL)stringIsNumeric:(NSString * _Nonnull)string;
	[Static]
	[Export ("stringIsNumeric:")]
	bool StringIsNumeric (string @string);

	// +(STPCardValidationState)validationStateForNumber:(NSString * _Nullable)cardNumber validatingCardBrand:(BOOL)validatingCardBrand;
	[Static]
	[Export ("validationStateForNumber:validatingCardBrand:")]
	STPCardValidationState ValidationStateForNumber ([NullAllowed] string cardNumber, bool validatingCardBrand);

	// +(STPCardBrand)brandForNumber:(NSString * _Nonnull)cardNumber;
	[Static]
	[Export ("brandForNumber:")]
	STPCardBrand BrandForNumber (string cardNumber);

	// +(NSSet<NSNumber *> * _Nonnull)lengthsForCardBrand:(STPCardBrand)brand;
	[Static]
	[Export ("lengthsForCardBrand:")]
	NSSet<NSNumber> LengthsForCardBrand (STPCardBrand brand);

	// +(NSInteger)maxLengthForCardBrand:(STPCardBrand)brand;
	[Static]
	[Export ("maxLengthForCardBrand:")]
	nint MaxLengthForCardBrand (STPCardBrand brand);

	// +(NSInteger)fragmentLengthForCardBrand:(STPCardBrand)brand;
	[Static]
	[Export ("fragmentLengthForCardBrand:")]
	nint FragmentLengthForCardBrand (STPCardBrand brand);

	// +(STPCardValidationState)validationStateForExpirationMonth:(NSString * _Nonnull)expirationMonth;
	[Static]
	[Export ("validationStateForExpirationMonth:")]
	STPCardValidationState ValidationStateForExpirationMonth (string expirationMonth);

	// +(STPCardValidationState)validationStateForExpirationYear:(NSString * _Nonnull)expirationYear inMonth:(NSString * _Nonnull)expirationMonth;
	[Static]
	[Export ("validationStateForExpirationYear:inMonth:")]
	STPCardValidationState ValidationStateForExpirationYear (string expirationYear, string expirationMonth);

	// +(NSUInteger)maxCVCLengthForCardBrand:(STPCardBrand)brand;
	[Static]
	[Export ("maxCVCLengthForCardBrand:")]
	nuint MaxCVCLengthForCardBrand (STPCardBrand brand);

	// +(STPCardValidationState)validationStateForCVC:(NSString * _Nonnull)cvc cardBrand:(STPCardBrand)brand;
	[Static]
	[Export ("validationStateForCVC:cardBrand:")]
	STPCardValidationState ValidationStateForCVC (string cvc, STPCardBrand brand);

	// +(STPCardValidationState)validationStateForCard:(STPCardParams * _Nonnull)card;
	[Static]
	[Export ("validationStateForCard:")]
	STPCardValidationState ValidationStateForCard (STPCardParams card);
}

// @interface STPConnectAccountParams : NSObject <STPFormEncodable>
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface STPConnectAccountParams : ISTPFormEncodable
{
	// @property (readonly, nonatomic) NSNumber * _Nullable tosShownAndAccepted;
	[NullAllowed, Export ("tosShownAndAccepted")]
	NSNumber TosShownAndAccepted { get; }

	// @property (readonly, nonatomic) STPLegalEntityParams * _Nonnull legalEntity;
	[Export ("legalEntity")]
	STPLegalEntityParams LegalEntity { get; }

	// -(instancetype _Nonnull)initWithTosShownAndAccepted:(BOOL)wasAccepted legalEntity:(STPLegalEntityParams * _Nonnull)legalEntity;
	[Export ("initWithTosShownAndAccepted:legalEntity:")]
	IntPtr Constructor (bool wasAccepted, STPLegalEntityParams legalEntity);

	// -(instancetype _Nonnull)initWithLegalEntity:(STPLegalEntityParams * _Nonnull)legalEntity;
	[Export ("initWithLegalEntity:")]
	IntPtr Constructor (STPLegalEntityParams legalEntity);
}

// @interface STPCustomerContext : NSObject <STPBackendAPIAdapter>
[BaseType (typeof(NSObject))]
interface STPCustomerContext : ISTPBackendAPIAdapter
{
	// -(instancetype _Nonnull)initWithKeyProvider:(id<STPCustomerEphemeralKeyProvider> _Nonnull)keyProvider;
	[Export ("initWithKeyProvider:")]
	IntPtr Constructor (STPCustomerEphemeralKeyProvider keyProvider);

	// -(void)clearCachedCustomer;
	[Export ("clearCachedCustomer")]
	void ClearCachedCustomer ();

	// @property (assign, nonatomic) BOOL includeApplePaySources;
	[Export ("includeApplePaySources")]
	bool IncludeApplePaySources { get; set; }
}

// @protocol STPCustomerEphemeralKeyProvider <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface STPCustomerEphemeralKeyProvider
{
	// @required -(void)createCustomerKeyWithAPIVersion:(NSString * _Nonnull)apiVersion completion:(STPJSONResponseCompletionBlock _Nonnull)completion;
	[Abstract]
	[Export ("createCustomerKeyWithAPIVersion:completion:")]
	void Completion (string apiVersion, STPJSONResponseCompletionBlock completion);
}

// @protocol STPIssuingCardEphemeralKeyProvider <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface STPIssuingCardEphemeralKeyProvider
{
	// @required -(void)createIssuingCardKeyWithAPIVersion:(NSString * _Nonnull)apiVersion completion:(STPJSONResponseCompletionBlock _Nonnull)completion;
	[Abstract]
	[Export ("createIssuingCardKeyWithAPIVersion:completion:")]
	void Completion (string apiVersion, STPJSONResponseCompletionBlock completion);
}

// @protocol STPEphemeralKeyProvider <STPCustomerEphemeralKeyProvider>
[Protocol, Model]
interface STPEphemeralKeyProvider : ISTPCustomerEphemeralKeyProvider
{
}

// @interface STPImageLibrary : NSObject
[BaseType (typeof(NSObject))]
interface STPImageLibrary
{
	// +(UIImage * _Nonnull)applePayCardImage;
	[Static]
	[Export ("applePayCardImage")]
	[Verify (MethodToProperty)]
	UIImage ApplePayCardImage { get; }

	// +(UIImage * _Nonnull)amexCardImage;
	[Static]
	[Export ("amexCardImage")]
	[Verify (MethodToProperty)]
	UIImage AmexCardImage { get; }

	// +(UIImage * _Nonnull)dinersClubCardImage;
	[Static]
	[Export ("dinersClubCardImage")]
	[Verify (MethodToProperty)]
	UIImage DinersClubCardImage { get; }

	// +(UIImage * _Nonnull)discoverCardImage;
	[Static]
	[Export ("discoverCardImage")]
	[Verify (MethodToProperty)]
	UIImage DiscoverCardImage { get; }

	// +(UIImage * _Nonnull)jcbCardImage;
	[Static]
	[Export ("jcbCardImage")]
	[Verify (MethodToProperty)]
	UIImage JcbCardImage { get; }

	// +(UIImage * _Nonnull)masterCardCardImage;
	[Static]
	[Export ("masterCardCardImage")]
	[Verify (MethodToProperty)]
	UIImage MasterCardCardImage { get; }

	// +(UIImage * _Nonnull)unionPayCardImage;
	[Static]
	[Export ("unionPayCardImage")]
	[Verify (MethodToProperty)]
	UIImage UnionPayCardImage { get; }

	// +(UIImage * _Nonnull)visaCardImage;
	[Static]
	[Export ("visaCardImage")]
	[Verify (MethodToProperty)]
	UIImage VisaCardImage { get; }

	// +(UIImage * _Nonnull)unknownCardCardImage;
	[Static]
	[Export ("unknownCardCardImage")]
	[Verify (MethodToProperty)]
	UIImage UnknownCardCardImage { get; }

	// +(UIImage * _Nonnull)brandImageForCardBrand:(STPCardBrand)brand;
	[Static]
	[Export ("brandImageForCardBrand:")]
	UIImage BrandImageForCardBrand (STPCardBrand brand);

	// +(UIImage * _Nonnull)templatedBrandImageForCardBrand:(STPCardBrand)brand;
	[Static]
	[Export ("templatedBrandImageForCardBrand:")]
	UIImage TemplatedBrandImageForCardBrand (STPCardBrand brand);

	// +(UIImage * _Nonnull)cvcImageForCardBrand:(STPCardBrand)brand;
	[Static]
	[Export ("cvcImageForCardBrand:")]
	UIImage CvcImageForCardBrand (STPCardBrand brand);

	// +(UIImage * _Nonnull)errorImageForCardBrand:(STPCardBrand)brand;
	[Static]
	[Export ("errorImageForCardBrand:")]
	UIImage ErrorImageForCardBrand (STPCardBrand brand);
}

// @interface STPPersonParams : NSObject <STPFormEncodable>
[BaseType (typeof(NSObject))]
interface STPPersonParams : ISTPFormEncodable
{
	// @property (copy, nonatomic) NSString * _Nullable firstName;
	[NullAllowed, Export ("firstName")]
	string FirstName { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable lastName;
	[NullAllowed, Export ("lastName")]
	string LastName { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable maidenName;
	[NullAllowed, Export ("maidenName")]
	string MaidenName { get; set; }

	// @property (nonatomic, strong) STPAddress * _Nullable address;
	[NullAllowed, Export ("address", ArgumentSemantic.Strong)]
	STPAddress Address { get; set; }

	// @property (copy, nonatomic) NSDateComponents * _Nullable dateOfBirth;
	[NullAllowed, Export ("dateOfBirth", ArgumentSemantic.Copy)]
	NSDateComponents DateOfBirth { get; set; }

	// @property (nonatomic, strong) STPVerificationParams * _Nullable verification;
	[NullAllowed, Export ("verification", ArgumentSemantic.Strong)]
	STPVerificationParams Verification { get; set; }
}

// @interface STPLegalEntityParams : STPPersonParams
[BaseType (typeof(STPPersonParams))]
interface STPLegalEntityParams
{
	// @property (copy, nonatomic) NSArray<STPPersonParams *> * _Nullable additionalOwners;
	[NullAllowed, Export ("additionalOwners", ArgumentSemantic.Copy)]
	STPPersonParams[] AdditionalOwners { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable businessName;
	[NullAllowed, Export ("businessName")]
	string BusinessName { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable businessTaxId;
	[NullAllowed, Export ("businessTaxId")]
	string BusinessTaxId { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable businessVATId;
	[NullAllowed, Export ("businessVATId")]
	string BusinessVATId { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable genderString;
	[NullAllowed, Export ("genderString")]
	string GenderString { get; set; }

	// @property (nonatomic, strong) STPAddress * _Nullable personalAddress;
	[NullAllowed, Export ("personalAddress", ArgumentSemantic.Strong)]
	STPAddress PersonalAddress { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable personalIdNumber;
	[NullAllowed, Export ("personalIdNumber")]
	string PersonalIdNumber { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable phoneNumber;
	[NullAllowed, Export ("phoneNumber")]
	string PhoneNumber { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable ssnLast4;
	[NullAllowed, Export ("ssnLast4")]
	string SsnLast4 { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable taxIdRegistrar;
	[NullAllowed, Export ("taxIdRegistrar")]
	string TaxIdRegistrar { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable entityTypeString;
	[NullAllowed, Export ("entityTypeString")]
	string EntityTypeString { get; set; }
}

// @interface STPVerificationParams : NSObject <STPFormEncodable>
[BaseType (typeof(NSObject))]
interface STPVerificationParams : ISTPFormEncodable
{
	// @property (copy, nonatomic) NSString * _Nullable document;
	[NullAllowed, Export ("document")]
	string Document { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable documentBack;
	[NullAllowed, Export ("documentBack")]
	string DocumentBack { get; set; }
}

// @interface STPPaymentActivityIndicatorView : UIView
[BaseType (typeof(UIView))]
interface STPPaymentActivityIndicatorView
{
	// -(void)setAnimating:(BOOL)animating animated:(BOOL)animated;
	[Export ("setAnimating:animated:")]
	void SetAnimating (bool animating, bool animated);

	// @property (nonatomic) BOOL animating;
	[Export ("animating")]
	bool Animating { get; set; }

	// @property (nonatomic) BOOL hidesWhenStopped;
	[Export ("hidesWhenStopped")]
	bool HidesWhenStopped { get; set; }
}

// @interface STPPaymentCardTextField : UIControl <UIKeyInput>
[BaseType (typeof(UIControl))]
interface STPPaymentCardTextField : IUIKeyInput
{
	[Wrap ("WeakDelegate")]
	[NullAllowed]
	STPPaymentCardTextFieldDelegate Delegate { get; set; }

	// @property (nonatomic, weak) id<STPPaymentCardTextFieldDelegate> _Nullable delegate __attribute__((iboutlet));
	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
	NSObject WeakDelegate { get; set; }

	// @property (copy, nonatomic) UIFont * _Null_unspecified font __attribute__((annotate("ui_appearance_selector")));
	[Export ("font", ArgumentSemantic.Copy)]
	UIFont Font { get; set; }

	// @property (copy, nonatomic) UIColor * _Null_unspecified textColor __attribute__((annotate("ui_appearance_selector")));
	[Export ("textColor", ArgumentSemantic.Copy)]
	UIColor TextColor { get; set; }

	// @property (copy, nonatomic) UIColor * _Null_unspecified textErrorColor __attribute__((annotate("ui_appearance_selector")));
	[Export ("textErrorColor", ArgumentSemantic.Copy)]
	UIColor TextErrorColor { get; set; }

	// @property (copy, nonatomic) UIColor * _Null_unspecified placeholderColor __attribute__((annotate("ui_appearance_selector")));
	[Export ("placeholderColor", ArgumentSemantic.Copy)]
	UIColor PlaceholderColor { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable numberPlaceholder;
	[NullAllowed, Export ("numberPlaceholder")]
	string NumberPlaceholder { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable expirationPlaceholder;
	[NullAllowed, Export ("expirationPlaceholder")]
	string ExpirationPlaceholder { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable cvcPlaceholder;
	[NullAllowed, Export ("cvcPlaceholder")]
	string CvcPlaceholder { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable postalCodePlaceholder;
	[NullAllowed, Export ("postalCodePlaceholder")]
	string PostalCodePlaceholder { get; set; }

	// @property (copy, nonatomic) UIColor * _Null_unspecified cursorColor __attribute__((annotate("ui_appearance_selector")));
	[Export ("cursorColor", ArgumentSemantic.Copy)]
	UIColor CursorColor { get; set; }

	// @property (copy, nonatomic) UIColor * _Nullable borderColor __attribute__((annotate("ui_appearance_selector")));
	[NullAllowed, Export ("borderColor", ArgumentSemantic.Copy)]
	UIColor BorderColor { get; set; }

	// @property (assign, nonatomic) CGFloat borderWidth __attribute__((annotate("ui_appearance_selector")));
	[Export ("borderWidth")]
	nfloat BorderWidth { get; set; }

	// @property (assign, nonatomic) CGFloat cornerRadius __attribute__((annotate("ui_appearance_selector")));
	[Export ("cornerRadius")]
	nfloat CornerRadius { get; set; }

	// @property (assign, nonatomic) UIKeyboardAppearance keyboardAppearance __attribute__((annotate("ui_appearance_selector")));
	[Export ("keyboardAppearance", ArgumentSemantic.Assign)]
	UIKeyboardAppearance KeyboardAppearance { get; set; }

	// @property (nonatomic, strong) UIView * _Nullable inputView;
	[NullAllowed, Export ("inputView", ArgumentSemantic.Strong)]
	UIView InputView { get; set; }

	// @property (nonatomic, strong) UIView * _Nullable inputAccessoryView;
	[NullAllowed, Export ("inputAccessoryView", ArgumentSemantic.Strong)]
	UIView InputAccessoryView { get; set; }

	// @property (readonly, nonatomic) UIImage * _Nullable brandImage;
	[NullAllowed, Export ("brandImage")]
	UIImage BrandImage { get; }

	// @property (readonly, nonatomic) BOOL isValid;
	[Export ("isValid")]
	bool IsValid { get; }

	// @property (getter = isEnabled, nonatomic) BOOL enabled;
	[Export ("enabled")]
	bool Enabled { [Bind ("isEnabled")] get; set; }

	// @property (readonly, nonatomic) NSString * _Nullable cardNumber;
	[NullAllowed, Export ("cardNumber")]
	string CardNumber { get; }

	// @property (readonly, nonatomic) NSUInteger expirationMonth;
	[Export ("expirationMonth")]
	nuint ExpirationMonth { get; }

	// @property (readonly, nonatomic) NSString * _Nullable formattedExpirationMonth;
	[NullAllowed, Export ("formattedExpirationMonth")]
	string FormattedExpirationMonth { get; }

	// @property (readonly, nonatomic) NSUInteger expirationYear;
	[Export ("expirationYear")]
	nuint ExpirationYear { get; }

	// @property (readonly, nonatomic) NSString * _Nullable formattedExpirationYear;
	[NullAllowed, Export ("formattedExpirationYear")]
	string FormattedExpirationYear { get; }

	// @property (readonly, nonatomic) NSString * _Nullable cvc;
	[NullAllowed, Export ("cvc")]
	string Cvc { get; }

	// @property (readonly, nonatomic) NSString * _Nullable postalCode;
	[NullAllowed, Export ("postalCode")]
	string PostalCode { get; }

	// @property (assign, readwrite, nonatomic) BOOL postalCodeEntryEnabled;
	[Export ("postalCodeEntryEnabled")]
	bool PostalCodeEntryEnabled { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable countryCode;
	[NullAllowed, Export ("countryCode")]
	string CountryCode { get; set; }

	// @property (readwrite, copy, nonatomic) STPCardParams * _Nonnull cardParams;
	[Export ("cardParams", ArgumentSemantic.Copy)]
	STPCardParams CardParams { get; set; }

	// -(BOOL)becomeFirstResponder;
	[Export ("becomeFirstResponder")]
	[Verify (MethodToProperty)]
	bool BecomeFirstResponder { get; }

	// -(BOOL)resignFirstResponder;
	[Export ("resignFirstResponder")]
	[Verify (MethodToProperty)]
	bool ResignFirstResponder { get; }

	// -(void)clear;
	[Export ("clear")]
	void Clear ();

	// +(UIImage * _Nullable)cvcImageForCardBrand:(STPCardBrand)cardBrand;
	[Static]
	[Export ("cvcImageForCardBrand:")]
	[return: NullAllowed]
	UIImage CvcImageForCardBrand (STPCardBrand cardBrand);

	// +(UIImage * _Nullable)brandImageForCardBrand:(STPCardBrand)cardBrand;
	[Static]
	[Export ("brandImageForCardBrand:")]
	[return: NullAllowed]
	UIImage BrandImageForCardBrand (STPCardBrand cardBrand);

	// +(UIImage * _Nullable)errorImageForCardBrand:(STPCardBrand)cardBrand;
	[Static]
	[Export ("errorImageForCardBrand:")]
	[return: NullAllowed]
	UIImage ErrorImageForCardBrand (STPCardBrand cardBrand);

	// -(CGRect)brandImageRectForBounds:(CGRect)bounds;
	[Export ("brandImageRectForBounds:")]
	CGRect BrandImageRectForBounds (CGRect bounds);

	// -(CGRect)fieldsRectForBounds:(CGRect)bounds;
	[Export ("fieldsRectForBounds:")]
	CGRect FieldsRectForBounds (CGRect bounds);
}

// @protocol STPPaymentCardTextFieldDelegate <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface STPPaymentCardTextFieldDelegate
{
	// @optional -(void)paymentCardTextFieldDidChange:(STPPaymentCardTextField * _Nonnull)textField;
	[Export ("paymentCardTextFieldDidChange:")]
	void PaymentCardTextFieldDidChange (STPPaymentCardTextField textField);

	// @optional -(void)paymentCardTextFieldDidBeginEditing:(STPPaymentCardTextField * _Nonnull)textField;
	[Export ("paymentCardTextFieldDidBeginEditing:")]
	void PaymentCardTextFieldDidBeginEditing (STPPaymentCardTextField textField);

	// @optional -(void)paymentCardTextFieldWillEndEditingForReturn:(STPPaymentCardTextField * _Nonnull)textField;
	[Export ("paymentCardTextFieldWillEndEditingForReturn:")]
	void PaymentCardTextFieldWillEndEditingForReturn (STPPaymentCardTextField textField);

	// @optional -(void)paymentCardTextFieldDidEndEditing:(STPPaymentCardTextField * _Nonnull)textField;
	[Export ("paymentCardTextFieldDidEndEditing:")]
	void PaymentCardTextFieldDidEndEditing (STPPaymentCardTextField textField);

	// @optional -(void)paymentCardTextFieldDidBeginEditingNumber:(STPPaymentCardTextField * _Nonnull)textField;
	[Export ("paymentCardTextFieldDidBeginEditingNumber:")]
	void PaymentCardTextFieldDidBeginEditingNumber (STPPaymentCardTextField textField);

	// @optional -(void)paymentCardTextFieldDidEndEditingNumber:(STPPaymentCardTextField * _Nonnull)textField;
	[Export ("paymentCardTextFieldDidEndEditingNumber:")]
	void PaymentCardTextFieldDidEndEditingNumber (STPPaymentCardTextField textField);

	// @optional -(void)paymentCardTextFieldDidBeginEditingCVC:(STPPaymentCardTextField * _Nonnull)textField;
	[Export ("paymentCardTextFieldDidBeginEditingCVC:")]
	void PaymentCardTextFieldDidBeginEditingCVC (STPPaymentCardTextField textField);

	// @optional -(void)paymentCardTextFieldDidEndEditingCVC:(STPPaymentCardTextField * _Nonnull)textField;
	[Export ("paymentCardTextFieldDidEndEditingCVC:")]
	void PaymentCardTextFieldDidEndEditingCVC (STPPaymentCardTextField textField);

	// @optional -(void)paymentCardTextFieldDidBeginEditingExpiration:(STPPaymentCardTextField * _Nonnull)textField;
	[Export ("paymentCardTextFieldDidBeginEditingExpiration:")]
	void PaymentCardTextFieldDidBeginEditingExpiration (STPPaymentCardTextField textField);

	// @optional -(void)paymentCardTextFieldDidEndEditingExpiration:(STPPaymentCardTextField * _Nonnull)textField;
	[Export ("paymentCardTextFieldDidEndEditingExpiration:")]
	void PaymentCardTextFieldDidEndEditingExpiration (STPPaymentCardTextField textField);

	// @optional -(void)paymentCardTextFieldDidBeginEditingPostalCode:(STPPaymentCardTextField * _Nonnull)textField;
	[Export ("paymentCardTextFieldDidBeginEditingPostalCode:")]
	void PaymentCardTextFieldDidBeginEditingPostalCode (STPPaymentCardTextField textField);

	// @optional -(void)paymentCardTextFieldDidEndEditingPostalCode:(STPPaymentCardTextField * _Nonnull)textField;
	[Export ("paymentCardTextFieldDidEndEditingPostalCode:")]
	void PaymentCardTextFieldDidEndEditingPostalCode (STPPaymentCardTextField textField);
}

// @interface STPPaymentResult : NSObject
[BaseType (typeof(NSObject))]
interface STPPaymentResult
{
	// @property (readonly, nonatomic) id<STPSourceProtocol> _Nonnull source;
	[Export ("source")]
	STPSourceProtocol Source { get; }

	// -(instancetype _Nonnull)initWithSource:(id<STPSourceProtocol> _Nonnull)source;
	[Export ("initWithSource:")]
	IntPtr Constructor (STPSourceProtocol source);
}

// @interface STPPaymentContext : NSObject
[BaseType (typeof(NSObject))]
interface STPPaymentContext
{
	// -(instancetype _Nonnull)initWithCustomerContext:(STPCustomerContext * _Nonnull)customerContext;
	[Export ("initWithCustomerContext:")]
	IntPtr Constructor (STPCustomerContext customerContext);

	// -(instancetype _Nonnull)initWithCustomerContext:(STPCustomerContext * _Nonnull)customerContext configuration:(STPPaymentConfiguration * _Nonnull)configuration theme:(STPTheme * _Nonnull)theme;
	[Export ("initWithCustomerContext:configuration:theme:")]
	IntPtr Constructor (STPCustomerContext customerContext, STPPaymentConfiguration configuration, STPTheme theme);

	// -(instancetype _Nonnull)initWithAPIAdapter:(id<STPBackendAPIAdapter> _Nonnull)apiAdapter;
	[Export ("initWithAPIAdapter:")]
	IntPtr Constructor (STPBackendAPIAdapter apiAdapter);

	// -(instancetype _Nonnull)initWithAPIAdapter:(id<STPBackendAPIAdapter> _Nonnull)apiAdapter configuration:(STPPaymentConfiguration * _Nonnull)configuration theme:(STPTheme * _Nonnull)theme;
	[Export ("initWithAPIAdapter:configuration:theme:")]
	IntPtr Constructor (STPBackendAPIAdapter apiAdapter, STPPaymentConfiguration configuration, STPTheme theme);

	// @property (readonly, nonatomic) id<STPBackendAPIAdapter> _Nonnull apiAdapter;
	[Export ("apiAdapter")]
	STPBackendAPIAdapter ApiAdapter { get; }

	// @property (readonly, nonatomic) STPPaymentConfiguration * _Nonnull configuration;
	[Export ("configuration")]
	STPPaymentConfiguration Configuration { get; }

	// @property (readonly, nonatomic) STPTheme * _Nonnull theme;
	[Export ("theme")]
	STPTheme Theme { get; }

	// @property (nonatomic, strong) STPUserInformation * _Nullable prefilledInformation;
	[NullAllowed, Export ("prefilledInformation", ArgumentSemantic.Strong)]
	STPUserInformation PrefilledInformation { get; set; }

	// @property (nonatomic, weak) UIViewController * _Nullable hostViewController;
	[NullAllowed, Export ("hostViewController", ArgumentSemantic.Weak)]
	UIViewController HostViewController { get; set; }

	[Wrap ("WeakDelegate")]
	[NullAllowed]
	STPPaymentContextDelegate Delegate { get; set; }

	// @property (nonatomic, weak) id<STPPaymentContextDelegate> _Nullable delegate;
	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
	NSObject WeakDelegate { get; set; }

	// @property (readonly, nonatomic) BOOL loading;
	[Export ("loading")]
	bool Loading { get; }

	// @property (readonly, nonatomic) id<STPPaymentOption> _Nullable selectedPaymentOption;
	[NullAllowed, Export ("selectedPaymentOption")]
	STPPaymentOption SelectedPaymentOption { get; }

	// @property (readonly, nonatomic) NSArray<id<STPPaymentOption>> * _Nullable paymentOptions;
	[NullAllowed, Export ("paymentOptions")]
	STPPaymentOption[] PaymentOptions { get; }

	// @property (readonly, nonatomic) PKShippingMethod * _Nullable selectedShippingMethod;
	[NullAllowed, Export ("selectedShippingMethod")]
	PKShippingMethod SelectedShippingMethod { get; }

	// @property (readonly, nonatomic) NSArray<PKShippingMethod *> * _Nullable shippingMethods;
	[NullAllowed, Export ("shippingMethods")]
	PKShippingMethod[] ShippingMethods { get; }

	// @property (readonly, nonatomic) STPAddress * _Nullable shippingAddress;
	[NullAllowed, Export ("shippingAddress")]
	STPAddress ShippingAddress { get; }

	// @property (nonatomic) NSInteger paymentAmount;
	[Export ("paymentAmount")]
	nint PaymentAmount { get; set; }

	// @property (copy, nonatomic) NSString * _Nonnull paymentCurrency;
	[Export ("paymentCurrency")]
	string PaymentCurrency { get; set; }

	// @property (copy, nonatomic) NSString * _Nonnull paymentCountry;
	[Export ("paymentCountry")]
	string PaymentCountry { get; set; }

	// @property (copy, nonatomic) NSArray<PKPaymentSummaryItem *> * _Nonnull paymentSummaryItems;
	[Export ("paymentSummaryItems", ArgumentSemantic.Copy)]
	PKPaymentSummaryItem[] PaymentSummaryItems { get; set; }

	// @property (assign, nonatomic) UIModalPresentationStyle modalPresentationStyle;
	[Export ("modalPresentationStyle", ArgumentSemantic.Assign)]
	UIModalPresentationStyle ModalPresentationStyle { get; set; }

	// @property (assign, nonatomic) UINavigationItemLargeTitleDisplayMode largeTitleDisplayMode __attribute__((availability(ios, introduced=11.0)));
	[iOS (11, 0)]
	[Export ("largeTitleDisplayMode", ArgumentSemantic.Assign)]
	UINavigationItemLargeTitleDisplayMode LargeTitleDisplayMode { get; set; }

	// @property (nonatomic, strong) UIView * _Nonnull paymentOptionsViewControllerFooterView;
	[Export ("paymentOptionsViewControllerFooterView", ArgumentSemantic.Strong)]
	UIView PaymentOptionsViewControllerFooterView { get; set; }

	// @property (nonatomic, strong) UIView * _Nonnull addCardViewControllerFooterView;
	[Export ("addCardViewControllerFooterView", ArgumentSemantic.Strong)]
	UIView AddCardViewControllerFooterView { get; set; }

	// -(void)retryLoading;
	[Export ("retryLoading")]
	void RetryLoading ();

	// -(void)presentPaymentOptionsViewController;
	[Export ("presentPaymentOptionsViewController")]
	void PresentPaymentOptionsViewController ();

	// -(void)pushPaymentOptionsViewController;
	[Export ("pushPaymentOptionsViewController")]
	void PushPaymentOptionsViewController ();

	// -(void)presentShippingViewController;
	[Export ("presentShippingViewController")]
	void PresentShippingViewController ();

	// -(void)pushShippingViewController;
	[Export ("pushShippingViewController")]
	void PushShippingViewController ();

	// -(void)requestPayment;
	[Export ("requestPayment")]
	void RequestPayment ();
}

// @protocol STPPaymentContextDelegate <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface STPPaymentContextDelegate
{
	// @required -(void)paymentContext:(STPPaymentContext * _Nonnull)paymentContext didFailToLoadWithError:(NSError * _Nonnull)error;
	[Abstract]
	[Export ("paymentContext:didFailToLoadWithError:")]
	void PaymentContext (STPPaymentContext paymentContext, NSError error);

	// @required -(void)paymentContextDidChange:(STPPaymentContext * _Nonnull)paymentContext;
	[Abstract]
	[Export ("paymentContextDidChange:")]
	void PaymentContextDidChange (STPPaymentContext paymentContext);

	// @required -(void)paymentContext:(STPPaymentContext * _Nonnull)paymentContext didCreatePaymentResult:(STPPaymentResult * _Nonnull)paymentResult completion:(STPErrorBlock _Nonnull)completion;
	[Abstract]
	[Export ("paymentContext:didCreatePaymentResult:completion:")]
	void PaymentContext (STPPaymentContext paymentContext, STPPaymentResult paymentResult, STPErrorBlock completion);

	// @required -(void)paymentContext:(STPPaymentContext * _Nonnull)paymentContext didFinishWithStatus:(STPPaymentStatus)status error:(NSError * _Nullable)error;
	[Abstract]
	[Export ("paymentContext:didFinishWithStatus:error:")]
	void PaymentContext (STPPaymentContext paymentContext, STPPaymentStatus status, [NullAllowed] NSError error);

	// @optional -(void)paymentContext:(STPPaymentContext * _Nonnull)paymentContext didUpdateShippingAddress:(STPAddress * _Nonnull)address completion:(STPShippingMethodsCompletionBlock _Nonnull)completion;
	[Export ("paymentContext:didUpdateShippingAddress:completion:")]
	void PaymentContext (STPPaymentContext paymentContext, STPAddress address, STPShippingMethodsCompletionBlock completion);
}

// @interface STPPaymentIntent : NSObject <STPAPIResponseDecodable>
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface STPPaymentIntent : ISTPAPIResponseDecodable
{
	// @property (readonly, nonatomic) NSString * _Nonnull stripeId;
	[Export ("stripeId")]
	string StripeId { get; }

	// @property (readonly, nonatomic) NSString * _Nonnull clientSecret;
	[Export ("clientSecret")]
	string ClientSecret { get; }

	// @property (readonly, nonatomic) NSNumber * _Nonnull amount;
	[Export ("amount")]
	NSNumber Amount { get; }

	// @property (readonly, nonatomic) NSDate * _Nullable canceledAt;
	[NullAllowed, Export ("canceledAt")]
	NSDate CanceledAt { get; }

	// @property (readonly, nonatomic) STPPaymentIntentCaptureMethod captureMethod;
	[Export ("captureMethod")]
	STPPaymentIntentCaptureMethod CaptureMethod { get; }

	// @property (readonly, nonatomic) STPPaymentIntentConfirmationMethod confirmationMethod;
	[Export ("confirmationMethod")]
	STPPaymentIntentConfirmationMethod ConfirmationMethod { get; }

	// @property (readonly, nonatomic) NSDate * _Nullable created;
	[NullAllowed, Export ("created")]
	NSDate Created { get; }

	// @property (readonly, nonatomic) NSString * _Nonnull currency;
	[Export ("currency")]
	string Currency { get; }

	// @property (readonly, nonatomic) NSString * _Nullable stripeDescription;
	[NullAllowed, Export ("stripeDescription")]
	string StripeDescription { get; }

	// @property (readonly, nonatomic) BOOL livemode;
	[Export ("livemode")]
	bool Livemode { get; }

	// @property (readonly, nonatomic) STPPaymentIntentAction * _Nullable nextAction;
	[NullAllowed, Export ("nextAction")]
	STPPaymentIntentAction NextAction { get; }

	// @property (readonly, nonatomic) NSString * _Nullable receiptEmail;
	[NullAllowed, Export ("receiptEmail")]
	string ReceiptEmail { get; }

	// @property (readonly, nonatomic) NSString * _Nullable sourceId;
	[NullAllowed, Export ("sourceId")]
	string SourceId { get; }

	// @property (readonly, nonatomic) NSString * _Nullable paymentMethodId;
	[NullAllowed, Export ("paymentMethodId")]
	string PaymentMethodId { get; }

	// @property (readonly, nonatomic) STPPaymentIntentStatus status;
	[Export ("status")]
	STPPaymentIntentStatus Status { get; }

	// @property (readonly, nonatomic) NSArray<NSNumber *> * _Nullable paymentMethodTypes;
	[NullAllowed, Export ("paymentMethodTypes")]
	NSNumber[] PaymentMethodTypes { get; }

	// @property (readonly, nonatomic) STPPaymentIntentAction * _Nullable nextSourceAction __attribute__((deprecated("Use nextAction instead", "nextAction")));
	[NullAllowed, Export ("nextSourceAction")]
	STPPaymentIntentAction NextSourceAction { get; }
}

// @interface STPPaymentIntentAction : NSObject <STPAPIResponseDecodable>
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface STPPaymentIntentAction : ISTPAPIResponseDecodable
{
	// @property (readonly, nonatomic) STPPaymentIntentActionType type;
	[Export ("type")]
	STPPaymentIntentActionType Type { get; }

	// @property (readonly, nonatomic, strong) STPPaymentIntentActionRedirectToURL * _Nullable redirectToURL;
	[NullAllowed, Export ("redirectToURL", ArgumentSemantic.Strong)]
	STPPaymentIntentActionRedirectToURL RedirectToURL { get; }

	// @property (readonly, nonatomic, strong) STPPaymentIntentActionRedirectToURL * _Nullable authorizeWithURL __attribute__((deprecated("Use `redirectToURL` instead", "redirectToURL")));
	[NullAllowed, Export ("authorizeWithURL", ArgumentSemantic.Strong)]
	STPPaymentIntentActionRedirectToURL AuthorizeWithURL { get; }
}

// @interface STPPaymentIntentActionRedirectToURL : NSObject <STPAPIResponseDecodable>
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface STPPaymentIntentActionRedirectToURL : ISTPAPIResponseDecodable
{
	// @property (readonly, nonatomic) NSURL * _Nonnull url;
	[Export ("url")]
	NSUrl Url { get; }

	// @property (readonly, nonatomic) NSURL * _Nullable returnURL;
	[NullAllowed, Export ("returnURL")]
	NSUrl ReturnURL { get; }
}

// @interface STPPaymentIntentParams : NSObject <STPFormEncodable>
[BaseType (typeof(NSObject))]
interface STPPaymentIntentParams : ISTPFormEncodable
{
	// -(instancetype _Nonnull)initWithClientSecret:(NSString * _Nonnull)clientSecret;
	[Export ("initWithClientSecret:")]
	IntPtr Constructor (string clientSecret);

	// @property (readonly, copy, nonatomic) NSString * _Nullable stripeId;
	[NullAllowed, Export ("stripeId")]
	string StripeId { get; }

	// @property (copy, nonatomic) NSString * _Nonnull clientSecret;
	[Export ("clientSecret")]
	string ClientSecret { get; set; }

	// @property (nonatomic, strong) STPPaymentMethodParams * _Nullable paymentMethodParams;
	[NullAllowed, Export ("paymentMethodParams", ArgumentSemantic.Strong)]
	STPPaymentMethodParams PaymentMethodParams { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable paymentMethodId;
	[NullAllowed, Export ("paymentMethodId")]
	string PaymentMethodId { get; set; }

	// @property (nonatomic, strong) STPSourceParams * _Nullable sourceParams;
	[NullAllowed, Export ("sourceParams", ArgumentSemantic.Strong)]
	STPSourceParams SourceParams { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable sourceId;
	[NullAllowed, Export ("sourceId")]
	string SourceId { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable receiptEmail;
	[NullAllowed, Export ("receiptEmail")]
	string ReceiptEmail { get; set; }

	// @property (nonatomic, strong) NSNumber * _Nullable savePaymentMethod;
	[NullAllowed, Export ("savePaymentMethod", ArgumentSemantic.Strong)]
	NSNumber SavePaymentMethod { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable returnURL;
	[NullAllowed, Export ("returnURL")]
	string ReturnURL { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable returnUrl __attribute__((deprecated("returnUrl has been renamed to returnURL", "returnURL")));
	[NullAllowed, Export ("returnUrl")]
	string ReturnUrl { get; set; }

	// @property (nonatomic, strong) NSNumber * _Nullable saveSourceToCustomer __attribute__((deprecated("saveSourceToCustomer has been renamed to savePaymentMethod", "saveSourceToCustomer")));
	[NullAllowed, Export ("saveSourceToCustomer", ArgumentSemantic.Strong)]
	NSNumber SaveSourceToCustomer { get; set; }
}

// @interface STPPaymentMethod : NSObject <STPAPIResponseDecodable>
[BaseType (typeof(NSObject))]
interface STPPaymentMethod : ISTPAPIResponseDecodable
{
	// @property (readonly, nonatomic) NSString * _Nonnull stripeId;
	[Export ("stripeId")]
	string StripeId { get; }

	// @property (readonly, nonatomic) NSDate * _Nullable created;
	[NullAllowed, Export ("created")]
	NSDate Created { get; }

	// @property (readonly, nonatomic) BOOL liveMode;
	[Export ("liveMode")]
	bool LiveMode { get; }

	// @property (readonly, nonatomic) STPPaymentMethodType type;
	[Export ("type")]
	STPPaymentMethodType Type { get; }

	// @property (readonly, nonatomic) STPPaymentMethodBillingDetails * _Nullable billingDetails;
	[NullAllowed, Export ("billingDetails")]
	STPPaymentMethodBillingDetails BillingDetails { get; }

	// @property (readonly, nonatomic) STPPaymentMethodCard * _Nullable card;
	[NullAllowed, Export ("card")]
	STPPaymentMethodCard Card { get; }

	// @property (readonly, nonatomic) STPPaymentMethodiDEAL * _Nullable iDEAL;
	[NullAllowed, Export ("iDEAL")]
	STPPaymentMethodiDEAL IDEAL { get; }

	// @property (readonly, nonatomic) STPPaymentMethodCardPresent * _Nullable cardPresent;
	[NullAllowed, Export ("cardPresent")]
	STPPaymentMethodCardPresent CardPresent { get; }

	// @property (readonly, nonatomic) NSString * _Nullable customerId;
	[NullAllowed, Export ("customerId")]
	string CustomerId { get; }

	// @property (readonly, nonatomic) NSDictionary<NSString *,NSString *> * _Nullable metadata;
	[NullAllowed, Export ("metadata")]
	NSDictionary<NSString, NSString> Metadata { get; }
}

// @interface STPPaymentMethodAddress : NSObject <STPAPIResponseDecodable, STPFormEncodable>
[BaseType (typeof(NSObject))]
interface STPPaymentMethodAddress : ISTPAPIResponseDecodable, ISTPFormEncodable
{
	// @property (readwrite, copy, nonatomic) NSString * _Nullable city;
	[NullAllowed, Export ("city")]
	string City { get; set; }

	// @property (readwrite, copy, nonatomic) NSString * _Nullable country;
	[NullAllowed, Export ("country")]
	string Country { get; set; }

	// @property (readwrite, copy, nonatomic) NSString * _Nullable line1;
	[NullAllowed, Export ("line1")]
	string Line1 { get; set; }

	// @property (readwrite, copy, nonatomic) NSString * _Nullable line2;
	[NullAllowed, Export ("line2")]
	string Line2 { get; set; }

	// @property (readwrite, copy, nonatomic) NSString * _Nullable postalCode;
	[NullAllowed, Export ("postalCode")]
	string PostalCode { get; set; }

	// @property (readwrite, copy, nonatomic) NSString * _Nullable state;
	[NullAllowed, Export ("state")]
	string State { get; set; }
}

// @interface STPPaymentMethodBillingDetails : NSObject <STPAPIResponseDecodable, STPFormEncodable>
[BaseType (typeof(NSObject))]
interface STPPaymentMethodBillingDetails : ISTPAPIResponseDecodable, ISTPFormEncodable
{
	// @property (nonatomic, strong) STPPaymentMethodAddress * _Nullable address;
	[NullAllowed, Export ("address", ArgumentSemantic.Strong)]
	STPPaymentMethodAddress Address { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable email;
	[NullAllowed, Export ("email")]
	string Email { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable name;
	[NullAllowed, Export ("name")]
	string Name { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable phone;
	[NullAllowed, Export ("phone")]
	string Phone { get; set; }
}

// @interface STPPaymentMethodCard : NSObject <STPAPIResponseDecodable>
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface STPPaymentMethodCard : ISTPAPIResponseDecodable
{
	// @property (readonly, nonatomic) STPCardBrand brand;
	[Export ("brand")]
	STPCardBrand Brand { get; }

	// @property (readonly, nonatomic) STPPaymentMethodCardChecks * _Nullable checks;
	[NullAllowed, Export ("checks")]
	STPPaymentMethodCardChecks Checks { get; }

	// @property (readonly, nonatomic) NSString * _Nullable country;
	[NullAllowed, Export ("country")]
	string Country { get; }

	// @property (readonly, nonatomic) NSInteger expMonth;
	[Export ("expMonth")]
	nint ExpMonth { get; }

	// @property (readonly, nonatomic) NSInteger expYear;
	[Export ("expYear")]
	nint ExpYear { get; }

	// @property (readonly, nonatomic) NSString * _Nullable funding;
	[NullAllowed, Export ("funding")]
	string Funding { get; }

	// @property (readonly, nonatomic) NSString * _Nullable last4;
	[NullAllowed, Export ("last4")]
	string Last4 { get; }

	// @property (readonly, nonatomic) NSString * _Nullable fingerprint;
	[NullAllowed, Export ("fingerprint")]
	string Fingerprint { get; }

	// @property (readonly, nonatomic) STPPaymentMethodThreeDSecureUsage * _Nullable threeDSecureUsage;
	[NullAllowed, Export ("threeDSecureUsage")]
	STPPaymentMethodThreeDSecureUsage ThreeDSecureUsage { get; }

	// @property (readonly, nonatomic) STPPaymentMethodCardWallet * _Nullable wallet;
	[NullAllowed, Export ("wallet")]
	STPPaymentMethodCardWallet Wallet { get; }
}

// @interface STPPaymentMethodCardChecks : NSObject <STPAPIResponseDecodable>
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface STPPaymentMethodCardChecks : ISTPAPIResponseDecodable
{
	// @property (readonly, nonatomic) STPPaymentMethodCardCheckResult addressLine1Check;
	[Export ("addressLine1Check")]
	STPPaymentMethodCardCheckResult AddressLine1Check { get; }

	// @property (readonly, nonatomic) STPPaymentMethodCardCheckResult addressPostalCodeCheck;
	[Export ("addressPostalCodeCheck")]
	STPPaymentMethodCardCheckResult AddressPostalCodeCheck { get; }

	// @property (readonly, nonatomic) STPPaymentMethodCardCheckResult cvcCheck;
	[Export ("cvcCheck")]
	STPPaymentMethodCardCheckResult CvcCheck { get; }
}

// @interface STPPaymentMethodCardParams : NSObject <STPFormEncodable>
[BaseType (typeof(NSObject))]
interface STPPaymentMethodCardParams : ISTPFormEncodable
{
	// -(instancetype _Nonnull)initWithCardSourceParams:(STPCardParams * _Nonnull)cardSourceParams;
	[Export ("initWithCardSourceParams:")]
	IntPtr Constructor (STPCardParams cardSourceParams);

	// @property (copy, nonatomic) NSString * _Nullable number;
	[NullAllowed, Export ("number")]
	string Number { get; set; }

	// @property (nonatomic) NSNumber * _Nullable expMonth;
	[NullAllowed, Export ("expMonth", ArgumentSemantic.Assign)]
	NSNumber ExpMonth { get; set; }

	// @property (nonatomic) NSNumber * _Nullable expYear;
	[NullAllowed, Export ("expYear", ArgumentSemantic.Assign)]
	NSNumber ExpYear { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable token;
	[NullAllowed, Export ("token")]
	string Token { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable cvc;
	[NullAllowed, Export ("cvc")]
	string Cvc { get; set; }
}

// @interface STPPaymentMethodCardPresent : NSObject <STPAPIResponseDecodable>
[BaseType (typeof(NSObject))]
interface STPPaymentMethodCardPresent : ISTPAPIResponseDecodable
{
}

// @interface STPPaymentMethodCardWallet : NSObject <STPAPIResponseDecodable>
[BaseType (typeof(NSObject))]
interface STPPaymentMethodCardWallet : ISTPAPIResponseDecodable
{
	// @property (readonly, nonatomic) STPPaymentMethodCardWalletType type;
	[Export ("type")]
	STPPaymentMethodCardWalletType Type { get; }

	// @property (readonly, nonatomic) STPPaymentMethodCardWalletMasterpass * _Nullable masterpass;
	[NullAllowed, Export ("masterpass")]
	STPPaymentMethodCardWalletMasterpass Masterpass { get; }

	// @property (readonly, nonatomic) STPPaymentMethodCardWalletVisaCheckout * _Nullable visaCheckout;
	[NullAllowed, Export ("visaCheckout")]
	STPPaymentMethodCardWalletVisaCheckout VisaCheckout { get; }
}

// @interface STPPaymentMethodCardWalletMasterpass : NSObject <STPAPIResponseDecodable>
[BaseType (typeof(NSObject))]
interface STPPaymentMethodCardWalletMasterpass : ISTPAPIResponseDecodable
{
	// @property (readonly, nonatomic) NSString * _Nullable email;
	[NullAllowed, Export ("email")]
	string Email { get; }

	// @property (readonly, nonatomic) NSString * _Nullable name;
	[NullAllowed, Export ("name")]
	string Name { get; }

	// @property (readonly, nonatomic) STPPaymentMethodAddress * _Nullable billingAddress;
	[NullAllowed, Export ("billingAddress")]
	STPPaymentMethodAddress BillingAddress { get; }

	// @property (readonly, nonatomic) STPPaymentMethodAddress * _Nullable shippingAddress;
	[NullAllowed, Export ("shippingAddress")]
	STPPaymentMethodAddress ShippingAddress { get; }
}

// @interface STPPaymentMethodCardWalletVisaCheckout : NSObject <STPAPIResponseDecodable>
[BaseType (typeof(NSObject))]
interface STPPaymentMethodCardWalletVisaCheckout : ISTPAPIResponseDecodable
{
	// @property (readonly, nonatomic) NSString * _Nullable email;
	[NullAllowed, Export ("email")]
	string Email { get; }

	// @property (readonly, nonatomic) NSString * _Nullable name;
	[NullAllowed, Export ("name")]
	string Name { get; }

	// @property (readonly, nonatomic) STPPaymentMethodAddress * _Nullable billingAddress;
	[NullAllowed, Export ("billingAddress")]
	STPPaymentMethodAddress BillingAddress { get; }

	// @property (readonly, nonatomic) STPPaymentMethodAddress * _Nullable shippingAddress;
	[NullAllowed, Export ("shippingAddress")]
	STPPaymentMethodAddress ShippingAddress { get; }
}

// @interface STPPaymentMethodiDEAL : NSObject <STPAPIResponseDecodable>
[BaseType (typeof(NSObject))]
interface STPPaymentMethodiDEAL : ISTPAPIResponseDecodable
{
	// @property (readonly, nonatomic) NSString * _Nullable bankName;
	[NullAllowed, Export ("bankName")]
	string BankName { get; }

	// @property (readonly, nonatomic) NSString * _Nullable bankIdentifierCode;
	[NullAllowed, Export ("bankIdentifierCode")]
	string BankIdentifierCode { get; }
}

// @interface STPPaymentMethodiDEALParams : NSObject <STPFormEncodable>
[BaseType (typeof(NSObject))]
interface STPPaymentMethodiDEALParams : ISTPFormEncodable
{
	// @property (copy, nonatomic) NSString * _Nullable bankName;
	[NullAllowed, Export ("bankName")]
	string BankName { get; set; }
}

// @interface STPPaymentMethodParams : NSObject <STPFormEncodable>
[BaseType (typeof(NSObject))]
interface STPPaymentMethodParams : ISTPFormEncodable
{
	// @property (readonly, nonatomic) STPPaymentMethodType type;
	[Export ("type")]
	STPPaymentMethodType Type { get; }

	// @property (copy, nonatomic) NSString * _Nonnull rawTypeString;
	[Export ("rawTypeString")]
	string RawTypeString { get; set; }

	// @property (nonatomic, strong) STPPaymentMethodBillingDetails * _Nullable billingDetails;
	[NullAllowed, Export ("billingDetails", ArgumentSemantic.Strong)]
	STPPaymentMethodBillingDetails BillingDetails { get; set; }

	// @property (nonatomic, strong) STPPaymentMethodCardParams * _Nullable card;
	[NullAllowed, Export ("card", ArgumentSemantic.Strong)]
	STPPaymentMethodCardParams Card { get; set; }

	// @property (nonatomic) STPPaymentMethodiDEALParams * _Nullable iDEAL;
	[NullAllowed, Export ("iDEAL", ArgumentSemantic.Assign)]
	STPPaymentMethodiDEALParams IDEAL { get; set; }

	// @property (copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nullable metadata;
	[NullAllowed, Export ("metadata", ArgumentSemantic.Copy)]
	NSDictionary<NSString, NSString> Metadata { get; set; }

	// +(STPPaymentMethodParams * _Nonnull)paramsWithCard:(STPPaymentMethodCardParams * _Nonnull)card billingDetails:(STPPaymentMethodBillingDetails * _Nullable)billingDetails metadata:(NSDictionary<NSString *,NSString *> * _Nullable)metadata;
	[Static]
	[Export ("paramsWithCard:billingDetails:metadata:")]
	STPPaymentMethodParams ParamsWithCard (STPPaymentMethodCardParams card, [NullAllowed] STPPaymentMethodBillingDetails billingDetails, [NullAllowed] NSDictionary<NSString, NSString> metadata);

	// +(STPPaymentMethodParams * _Nonnull)paramsWithiDEAL:(STPPaymentMethodiDEALParams * _Nonnull)iDEAL billingDetails:(STPPaymentMethodBillingDetails * _Nullable)billingDetails metadata:(NSDictionary<NSString *,NSString *> * _Nullable)metadata;
	[Static]
	[Export ("paramsWithiDEAL:billingDetails:metadata:")]
	STPPaymentMethodParams ParamsWithiDEAL (STPPaymentMethodiDEALParams iDEAL, [NullAllowed] STPPaymentMethodBillingDetails billingDetails, [NullAllowed] NSDictionary<NSString, NSString> metadata);
}

// @interface STPPaymentMethodThreeDSecureUsage : NSObject <STPAPIResponseDecodable>
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface STPPaymentMethodThreeDSecureUsage : ISTPAPIResponseDecodable
{
	// @property (readonly, nonatomic) BOOL supported;
	[Export ("supported")]
	bool Supported { get; }
}

// @interface STPPaymentOptionsViewController : STPCoreViewController
[BaseType (typeof(STPCoreViewController))]
interface STPPaymentOptionsViewController
{
	[Wrap ("WeakDelegate")]
	[NullAllowed]
	STPPaymentOptionsViewControllerDelegate Delegate { get; }

	// @property (readonly, nonatomic, weak) id<STPPaymentOptionsViewControllerDelegate> _Nullable delegate;
	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
	NSObject WeakDelegate { get; }

	// -(instancetype _Nonnull)initWithPaymentContext:(STPPaymentContext * _Nonnull)paymentContext;
	[Export ("initWithPaymentContext:")]
	IntPtr Constructor (STPPaymentContext paymentContext);

	// -(instancetype _Nonnull)initWithConfiguration:(STPPaymentConfiguration * _Nonnull)configuration theme:(STPTheme * _Nonnull)theme customerContext:(STPCustomerContext * _Nonnull)customerContext delegate:(id<STPPaymentOptionsViewControllerDelegate> _Nonnull)delegate;
	[Export ("initWithConfiguration:theme:customerContext:delegate:")]
	IntPtr Constructor (STPPaymentConfiguration configuration, STPTheme theme, STPCustomerContext customerContext, STPPaymentOptionsViewControllerDelegate @delegate);

	// -(instancetype _Nonnull)initWithConfiguration:(STPPaymentConfiguration * _Nonnull)configuration theme:(STPTheme * _Nonnull)theme apiAdapter:(id<STPBackendAPIAdapter> _Nonnull)apiAdapter delegate:(id<STPPaymentOptionsViewControllerDelegate> _Nonnull)delegate;
	[Export ("initWithConfiguration:theme:apiAdapter:delegate:")]
	IntPtr Constructor (STPPaymentConfiguration configuration, STPTheme theme, STPBackendAPIAdapter apiAdapter, STPPaymentOptionsViewControllerDelegate @delegate);

	// @property (nonatomic, strong) STPUserInformation * _Nullable prefilledInformation;
	[NullAllowed, Export ("prefilledInformation", ArgumentSemantic.Strong)]
	STPUserInformation PrefilledInformation { get; set; }

	// @property (nonatomic, strong) UIView * _Nonnull paymentOptionsViewControllerFooterView;
	[Export ("paymentOptionsViewControllerFooterView", ArgumentSemantic.Strong)]
	UIView PaymentOptionsViewControllerFooterView { get; set; }

	// @property (nonatomic, strong) UIView * _Nonnull addCardViewControllerFooterView;
	[Export ("addCardViewControllerFooterView", ArgumentSemantic.Strong)]
	UIView AddCardViewControllerFooterView { get; set; }

	// -(void)dismissWithCompletion:(STPVoidBlock _Nullable)completion;
	[Export ("dismissWithCompletion:")]
	void DismissWithCompletion ([NullAllowed] STPVoidBlock completion);
}

// @protocol STPPaymentOptionsViewControllerDelegate <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface STPPaymentOptionsViewControllerDelegate
{
	// @required -(void)paymentOptionsViewController:(STPPaymentOptionsViewController * _Nonnull)paymentOptionsViewController didFailToLoadWithError:(NSError * _Nonnull)error;
	[Abstract]
	[Export ("paymentOptionsViewController:didFailToLoadWithError:")]
	void PaymentOptionsViewController (STPPaymentOptionsViewController paymentOptionsViewController, NSError error);

	// @required -(void)paymentOptionsViewControllerDidFinish:(STPPaymentOptionsViewController * _Nonnull)paymentOptionsViewController;
	[Abstract]
	[Export ("paymentOptionsViewControllerDidFinish:")]
	void PaymentOptionsViewControllerDidFinish (STPPaymentOptionsViewController paymentOptionsViewController);

	// @required -(void)paymentOptionsViewControllerDidCancel:(STPPaymentOptionsViewController * _Nonnull)paymentOptionsViewController;
	[Abstract]
	[Export ("paymentOptionsViewControllerDidCancel:")]
	void PaymentOptionsViewControllerDidCancel (STPPaymentOptionsViewController paymentOptionsViewController);

	// @optional -(void)paymentOptionsViewController:(STPPaymentOptionsViewController * _Nonnull)paymentOptionsViewController didSelectPaymentOption:(id<STPPaymentOption> _Nonnull)paymentOption;
	[Export ("paymentOptionsViewController:didSelectPaymentOption:")]
	void PaymentOptionsViewController (STPPaymentOptionsViewController paymentOptionsViewController, STPPaymentOption paymentOption);
}

// typedef void (^STPRedirectContextSourceCompletionBlock)(NSString * _Nonnull, NSString * _Nullable, NSError * _Nullable);
delegate void STPRedirectContextSourceCompletionBlock (string arg0, [NullAllowed] string arg1, [NullAllowed] NSError arg2);

// typedef STPRedirectContextSourceCompletionBlock STPRedirectContextCompletionBlock;
delegate void STPRedirectContextCompletionBlock (string arg0, [NullAllowed] string arg1, [NullAllowed] NSError arg2);

// typedef void (^STPRedirectContextPaymentIntentCompletionBlock)(NSString * _Nonnull, NSError * _Nullable);
delegate void STPRedirectContextPaymentIntentCompletionBlock (string arg0, [NullAllowed] NSError arg1);

// @interface STPRedirectContext : NSObject
[Unavailable (PlatformName.iOSAppExtension)]
[Unavailable (PlatformName.MacOSXAppExtension)]
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface STPRedirectContext
{
	// @property (readonly, nonatomic) STPRedirectContextState state;
	[Export ("state")]
	STPRedirectContextState State { get; }

	// -(instancetype _Nullable)initWithSource:(STPSource * _Nonnull)source completion:(STPRedirectContextSourceCompletionBlock _Nonnull)completion;
	[Export ("initWithSource:completion:")]
	IntPtr Constructor (STPSource source, STPRedirectContextSourceCompletionBlock completion);

	// -(instancetype _Nullable)initWithPaymentIntent:(STPPaymentIntent * _Nonnull)paymentIntent completion:(STPRedirectContextPaymentIntentCompletionBlock _Nonnull)completion;
	[Export ("initWithPaymentIntent:completion:")]
	IntPtr Constructor (STPPaymentIntent paymentIntent, STPRedirectContextPaymentIntentCompletionBlock completion);

	// -(void)startRedirectFlowFromViewController:(UIViewController * _Nonnull)presentingViewController;
	[Export ("startRedirectFlowFromViewController:")]
	void StartRedirectFlowFromViewController (UIViewController presentingViewController);

	// -(void)startSafariViewControllerRedirectFlowFromViewController:(UIViewController * _Nonnull)presentingViewController;
	[Export ("startSafariViewControllerRedirectFlowFromViewController:")]
	void StartSafariViewControllerRedirectFlowFromViewController (UIViewController presentingViewController);

	// -(void)startSafariAppRedirectFlow;
	[Export ("startSafariAppRedirectFlow")]
	void StartSafariAppRedirectFlow ();

	// -(void)cancel;
	[Export ("cancel")]
	void Cancel ();
}

// @interface STPShippingAddressViewController : STPCoreTableViewController
[BaseType (typeof(STPCoreTableViewController))]
interface STPShippingAddressViewController
{
	// -(instancetype _Nonnull)initWithPaymentContext:(STPPaymentContext * _Nonnull)paymentContext;
	[Export ("initWithPaymentContext:")]
	IntPtr Constructor (STPPaymentContext paymentContext);

	// -(instancetype _Nonnull)initWithConfiguration:(STPPaymentConfiguration * _Nonnull)configuration theme:(STPTheme * _Nonnull)theme currency:(NSString * _Nullable)currency shippingAddress:(STPAddress * _Nullable)shippingAddress selectedShippingMethod:(PKShippingMethod * _Nullable)selectedShippingMethod prefilledInformation:(STPUserInformation * _Nullable)prefilledInformation;
	[Export ("initWithConfiguration:theme:currency:shippingAddress:selectedShippingMethod:prefilledInformation:")]
	IntPtr Constructor (STPPaymentConfiguration configuration, STPTheme theme, [NullAllowed] string currency, [NullAllowed] STPAddress shippingAddress, [NullAllowed] PKShippingMethod selectedShippingMethod, [NullAllowed] STPUserInformation prefilledInformation);

	[Wrap ("WeakDelegate")]
	[NullAllowed]
	STPShippingAddressViewControllerDelegate Delegate { get; set; }

	// @property (nonatomic, weak) id<STPShippingAddressViewControllerDelegate> _Nullable delegate;
	[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
	NSObject WeakDelegate { get; set; }

	// -(void)dismissWithCompletion:(STPVoidBlock _Nullable)completion;
	[Export ("dismissWithCompletion:")]
	void DismissWithCompletion ([NullAllowed] STPVoidBlock completion);
}

// @protocol STPShippingAddressViewControllerDelegate <NSObject>
[Protocol, Model]
[BaseType (typeof(NSObject))]
interface STPShippingAddressViewControllerDelegate
{
	// @required -(void)shippingAddressViewControllerDidCancel:(STPShippingAddressViewController * _Nonnull)addressViewController;
	[Abstract]
	[Export ("shippingAddressViewControllerDidCancel:")]
	void ShippingAddressViewControllerDidCancel (STPShippingAddressViewController addressViewController);

	// @required -(void)shippingAddressViewController:(STPShippingAddressViewController * _Nonnull)addressViewController didEnterAddress:(STPAddress * _Nonnull)address completion:(STPShippingMethodsCompletionBlock _Nonnull)completion;
	[Abstract]
	[Export ("shippingAddressViewController:didEnterAddress:completion:")]
	void ShippingAddressViewController (STPShippingAddressViewController addressViewController, STPAddress address, STPShippingMethodsCompletionBlock completion);

	// @required -(void)shippingAddressViewController:(STPShippingAddressViewController * _Nonnull)addressViewController didFinishWithAddress:(STPAddress * _Nonnull)address shippingMethod:(PKShippingMethod * _Nullable)method;
	[Abstract]
	[Export ("shippingAddressViewController:didFinishWithAddress:shippingMethod:")]
	void ShippingAddressViewController (STPShippingAddressViewController addressViewController, STPAddress address, [NullAllowed] PKShippingMethod method);
}

// @interface STPSourceCardDetails : NSObject <STPAPIResponseDecodable>
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface STPSourceCardDetails : ISTPAPIResponseDecodable
{
	// @property (readonly, nonatomic) NSString * _Nullable last4;
	[NullAllowed, Export ("last4")]
	string Last4 { get; }

	// @property (readonly, nonatomic) NSUInteger expMonth;
	[Export ("expMonth")]
	nuint ExpMonth { get; }

	// @property (readonly, nonatomic) NSUInteger expYear;
	[Export ("expYear")]
	nuint ExpYear { get; }

	// @property (readonly, nonatomic) STPCardBrand brand;
	[Export ("brand")]
	STPCardBrand Brand { get; }

	// @property (readonly, nonatomic) STPCardFundingType funding;
	[Export ("funding")]
	STPCardFundingType Funding { get; }

	// @property (readonly, nonatomic) NSString * _Nullable country;
	[NullAllowed, Export ("country")]
	string Country { get; }

	// @property (readonly, nonatomic) STPSourceCard3DSecureStatus threeDSecure;
	[Export ("threeDSecure")]
	STPSourceCard3DSecureStatus ThreeDSecure { get; }

	// @property (readonly, nonatomic) BOOL isApplePayCard;
	[Export ("isApplePayCard")]
	bool IsApplePayCard { get; }
}

// @interface STPSourceOwner : NSObject <STPAPIResponseDecodable>
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface STPSourceOwner : ISTPAPIResponseDecodable
{
	// @property (readonly, nonatomic) STPAddress * _Nullable address;
	[NullAllowed, Export ("address")]
	STPAddress Address { get; }

	// @property (readonly, nonatomic) NSString * _Nullable email;
	[NullAllowed, Export ("email")]
	string Email { get; }

	// @property (readonly, nonatomic) NSString * _Nullable name;
	[NullAllowed, Export ("name")]
	string Name { get; }

	// @property (readonly, nonatomic) NSString * _Nullable phone;
	[NullAllowed, Export ("phone")]
	string Phone { get; }

	// @property (readonly, nonatomic) STPAddress * _Nullable verifiedAddress;
	[NullAllowed, Export ("verifiedAddress")]
	STPAddress VerifiedAddress { get; }

	// @property (readonly, nonatomic) NSString * _Nullable verifiedEmail;
	[NullAllowed, Export ("verifiedEmail")]
	string VerifiedEmail { get; }

	// @property (readonly, nonatomic) NSString * _Nullable verifiedName;
	[NullAllowed, Export ("verifiedName")]
	string VerifiedName { get; }

	// @property (readonly, nonatomic) NSString * _Nullable verifiedPhone;
	[NullAllowed, Export ("verifiedPhone")]
	string VerifiedPhone { get; }
}

// @interface STPSourceReceiver : NSObject <STPAPIResponseDecodable>
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface STPSourceReceiver : ISTPAPIResponseDecodable
{
	// @property (readonly, nonatomic) NSString * _Nullable address;
	[NullAllowed, Export ("address")]
	string Address { get; }

	// @property (readonly, nonatomic) NSNumber * _Nullable amountCharged;
	[NullAllowed, Export ("amountCharged")]
	NSNumber AmountCharged { get; }

	// @property (readonly, nonatomic) NSNumber * _Nullable amountReceived;
	[NullAllowed, Export ("amountReceived")]
	NSNumber AmountReceived { get; }

	// @property (readonly, nonatomic) NSNumber * _Nullable amountReturned;
	[NullAllowed, Export ("amountReturned")]
	NSNumber AmountReturned { get; }
}

// @interface STPSourceRedirect : NSObject <STPAPIResponseDecodable>
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface STPSourceRedirect : ISTPAPIResponseDecodable
{
	// @property (readonly, nonatomic) NSURL * _Nullable returnURL;
	[NullAllowed, Export ("returnURL")]
	NSUrl ReturnURL { get; }

	// @property (readonly, nonatomic) STPSourceRedirectStatus status;
	[Export ("status")]
	STPSourceRedirectStatus Status { get; }

	// @property (readonly, nonatomic) NSURL * _Nullable url;
	[NullAllowed, Export ("url")]
	NSUrl Url { get; }
}

// @interface STPSourceSEPADebitDetails : NSObject <STPAPIResponseDecodable>
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface STPSourceSEPADebitDetails : ISTPAPIResponseDecodable
{
	// @property (readonly, nonatomic) NSString * _Nullable last4;
	[NullAllowed, Export ("last4")]
	string Last4 { get; }

	// @property (readonly, nonatomic) NSString * _Nullable bankCode;
	[NullAllowed, Export ("bankCode")]
	string BankCode { get; }

	// @property (readonly, nonatomic) NSString * _Nullable country;
	[NullAllowed, Export ("country")]
	string Country { get; }

	// @property (readonly, nonatomic) NSString * _Nullable fingerprint;
	[NullAllowed, Export ("fingerprint")]
	string Fingerprint { get; }

	// @property (readonly, nonatomic) NSString * _Nullable mandateReference;
	[NullAllowed, Export ("mandateReference")]
	string MandateReference { get; }

	// @property (readonly, nonatomic) NSURL * _Nullable mandateURL;
	[NullAllowed, Export ("mandateURL")]
	NSUrl MandateURL { get; }
}

// @interface STPSourceVerification : NSObject <STPAPIResponseDecodable>
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface STPSourceVerification : ISTPAPIResponseDecodable
{
	// @property (readonly, nonatomic) NSNumber * _Nullable attemptsRemaining;
	[NullAllowed, Export ("attemptsRemaining")]
	NSNumber AttemptsRemaining { get; }

	// @property (readonly, nonatomic) STPSourceVerificationStatus status;
	[Export ("status")]
	STPSourceVerificationStatus Status { get; }
}

// @interface STPSource : NSObject <STPAPIResponseDecodable, STPSourceProtocol, STPPaymentOption>
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface STPSource : ISTPAPIResponseDecodable, ISTPSourceProtocol, ISTPPaymentOption
{
	// @property (readonly, nonatomic) NSNumber * _Nullable amount;
	[NullAllowed, Export ("amount")]
	NSNumber Amount { get; }

	// @property (readonly, nonatomic) NSString * _Nullable clientSecret;
	[NullAllowed, Export ("clientSecret")]
	string ClientSecret { get; }

	// @property (readonly, nonatomic) NSDate * _Nullable created;
	[NullAllowed, Export ("created")]
	NSDate Created { get; }

	// @property (readonly, nonatomic) NSString * _Nullable currency;
	[NullAllowed, Export ("currency")]
	string Currency { get; }

	// @property (readonly, nonatomic) STPSourceFlow flow;
	[Export ("flow")]
	STPSourceFlow Flow { get; }

	// @property (readonly, nonatomic) BOOL livemode;
	[Export ("livemode")]
	bool Livemode { get; }

	// @property (readonly, copy, nonatomic) NSDictionary<NSString *,NSString *> * _Nullable metadata;
	[NullAllowed, Export ("metadata", ArgumentSemantic.Copy)]
	NSDictionary<NSString, NSString> Metadata { get; }

	// @property (readonly, nonatomic) STPSourceOwner * _Nullable owner;
	[NullAllowed, Export ("owner")]
	STPSourceOwner Owner { get; }

	// @property (readonly, nonatomic) STPSourceReceiver * _Nullable receiver;
	[NullAllowed, Export ("receiver")]
	STPSourceReceiver Receiver { get; }

	// @property (readonly, nonatomic) STPSourceRedirect * _Nullable redirect;
	[NullAllowed, Export ("redirect")]
	STPSourceRedirect Redirect { get; }

	// @property (readonly, nonatomic) STPSourceStatus status;
	[Export ("status")]
	STPSourceStatus Status { get; }

	// @property (readonly, nonatomic) STPSourceType type;
	[Export ("type")]
	STPSourceType Type { get; }

	// @property (readonly, nonatomic) STPSourceUsage usage;
	[Export ("usage")]
	STPSourceUsage Usage { get; }

	// @property (readonly, nonatomic) STPSourceVerification * _Nullable verification;
	[NullAllowed, Export ("verification")]
	STPSourceVerification Verification { get; }

	// @property (readonly, nonatomic) NSDictionary * _Nullable details;
	[NullAllowed, Export ("details")]
	NSDictionary Details { get; }

	// @property (readonly, nonatomic) STPSourceCardDetails * _Nullable cardDetails;
	[NullAllowed, Export ("cardDetails")]
	STPSourceCardDetails CardDetails { get; }

	// @property (readonly, nonatomic) STPSourceSEPADebitDetails * _Nullable sepaDebitDetails;
	[NullAllowed, Export ("sepaDebitDetails")]
	STPSourceSEPADebitDetails SepaDebitDetails { get; }
}

// @interface STPSourceParams : NSObject <STPFormEncodable, NSCopying>
[BaseType (typeof(NSObject))]
interface STPSourceParams : ISTPFormEncodable, INSCopying
{
	// @property (assign, nonatomic) STPSourceType type;
	[Export ("type", ArgumentSemantic.Assign)]
	STPSourceType Type { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable rawTypeString;
	[NullAllowed, Export ("rawTypeString")]
	string RawTypeString { get; set; }

	// @property (copy, nonatomic) NSNumber * _Nullable amount;
	[NullAllowed, Export ("amount", ArgumentSemantic.Copy)]
	NSNumber Amount { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable currency;
	[NullAllowed, Export ("currency")]
	string Currency { get; set; }

	// @property (assign, nonatomic) STPSourceFlow flow;
	[Export ("flow", ArgumentSemantic.Assign)]
	STPSourceFlow Flow { get; set; }

	// @property (copy, nonatomic) NSDictionary * _Nullable metadata;
	[NullAllowed, Export ("metadata", ArgumentSemantic.Copy)]
	NSDictionary Metadata { get; set; }

	// @property (copy, nonatomic) NSDictionary * _Nullable owner;
	[NullAllowed, Export ("owner", ArgumentSemantic.Copy)]
	NSDictionary Owner { get; set; }

	// @property (copy, nonatomic) NSDictionary * _Nullable redirect;
	[NullAllowed, Export ("redirect", ArgumentSemantic.Copy)]
	NSDictionary Redirect { get; set; }

	// @property (copy, nonatomic) NSString * _Nullable token;
	[NullAllowed, Export ("token")]
	string Token { get; set; }

	// @property (assign, nonatomic) STPSourceUsage usage;
	[Export ("usage", ArgumentSemantic.Assign)]
	STPSourceUsage Usage { get; set; }

	// +(STPSourceParams * _Nonnull)bancontactParamsWithAmount:(NSUInteger)amount name:(NSString * _Nonnull)name returnURL:(NSString * _Nonnull)returnURL statementDescriptor:(NSString * _Nullable)statementDescriptor;
	[Static]
	[Export ("bancontactParamsWithAmount:name:returnURL:statementDescriptor:")]
	STPSourceParams BancontactParamsWithAmount (nuint amount, string name, string returnURL, [NullAllowed] string statementDescriptor);

	// +(STPSourceParams * _Nonnull)cardParamsWithCard:(STPCardParams * _Nonnull)card;
	[Static]
	[Export ("cardParamsWithCard:")]
	STPSourceParams CardParamsWithCard (STPCardParams card);

	// +(STPSourceParams * _Nonnull)giropayParamsWithAmount:(NSUInteger)amount name:(NSString * _Nonnull)name returnURL:(NSString * _Nonnull)returnURL statementDescriptor:(NSString * _Nullable)statementDescriptor;
	[Static]
	[Export ("giropayParamsWithAmount:name:returnURL:statementDescriptor:")]
	STPSourceParams GiropayParamsWithAmount (nuint amount, string name, string returnURL, [NullAllowed] string statementDescriptor);

	// +(STPSourceParams * _Nonnull)idealParamsWithAmount:(NSUInteger)amount name:(NSString * _Nullable)name returnURL:(NSString * _Nonnull)returnURL statementDescriptor:(NSString * _Nullable)statementDescriptor bank:(NSString * _Nullable)bank;
	[Static]
	[Export ("idealParamsWithAmount:name:returnURL:statementDescriptor:bank:")]
	STPSourceParams IdealParamsWithAmount (nuint amount, [NullAllowed] string name, string returnURL, [NullAllowed] string statementDescriptor, [NullAllowed] string bank);

	// +(STPSourceParams * _Nonnull)sepaDebitParamsWithName:(NSString * _Nonnull)name iban:(NSString * _Nonnull)iban addressLine1:(NSString * _Nullable)addressLine1 city:(NSString * _Nullable)city postalCode:(NSString * _Nullable)postalCode country:(NSString * _Nullable)country;
	[Static]
	[Export ("sepaDebitParamsWithName:iban:addressLine1:city:postalCode:country:")]
	STPSourceParams SepaDebitParamsWithName (string name, string iban, [NullAllowed] string addressLine1, [NullAllowed] string city, [NullAllowed] string postalCode, [NullAllowed] string country);

	// +(STPSourceParams * _Nonnull)sofortParamsWithAmount:(NSUInteger)amount returnURL:(NSString * _Nonnull)returnURL country:(NSString * _Nonnull)country statementDescriptor:(NSString * _Nullable)statementDescriptor;
	[Static]
	[Export ("sofortParamsWithAmount:returnURL:country:statementDescriptor:")]
	STPSourceParams SofortParamsWithAmount (nuint amount, string returnURL, string country, [NullAllowed] string statementDescriptor);

	// +(STPSourceParams * _Nonnull)threeDSecureParamsWithAmount:(NSUInteger)amount currency:(NSString * _Nonnull)currency returnURL:(NSString * _Nonnull)returnURL card:(NSString * _Nonnull)card;
	[Static]
	[Export ("threeDSecureParamsWithAmount:currency:returnURL:card:")]
	STPSourceParams ThreeDSecureParamsWithAmount (nuint amount, string currency, string returnURL, string card);

	// +(STPSourceParams * _Nonnull)alipayParamsWithAmount:(NSUInteger)amount currency:(NSString * _Nonnull)currency returnURL:(NSString * _Nonnull)returnURL;
	[Static]
	[Export ("alipayParamsWithAmount:currency:returnURL:")]
	STPSourceParams AlipayParamsWithAmount (nuint amount, string currency, string returnURL);

	// +(STPSourceParams * _Nonnull)alipayReusableParamsWithCurrency:(NSString * _Nonnull)currency returnURL:(NSString * _Nonnull)returnURL;
	[Static]
	[Export ("alipayReusableParamsWithCurrency:returnURL:")]
	STPSourceParams AlipayReusableParamsWithCurrency (string currency, string returnURL);

	// +(STPSourceParams * _Nonnull)p24ParamsWithAmount:(NSUInteger)amount currency:(NSString * _Nonnull)currency email:(NSString * _Nonnull)email name:(NSString * _Nullable)name returnURL:(NSString * _Nonnull)returnURL;
	[Static]
	[Export ("p24ParamsWithAmount:currency:email:name:returnURL:")]
	STPSourceParams P24ParamsWithAmount (nuint amount, string currency, string email, [NullAllowed] string name, string returnURL);

	// +(STPSourceParams * _Nonnull)visaCheckoutParamsWithCallId:(NSString * _Nonnull)callId;
	[Static]
	[Export ("visaCheckoutParamsWithCallId:")]
	STPSourceParams VisaCheckoutParamsWithCallId (string callId);

	// +(STPSourceParams * _Nonnull)masterpassParamsWithCartId:(NSString * _Nonnull)cartId transactionId:(NSString * _Nonnull)transactionId;
	[Static]
	[Export ("masterpassParamsWithCartId:transactionId:")]
	STPSourceParams MasterpassParamsWithCartId (string cartId, string transactionId);

	// +(STPSourceParams * _Nonnull)epsParamsWithAmount:(NSUInteger)amount name:(NSString * _Nonnull)name returnURL:(NSString * _Nonnull)returnURL statementDescriptor:(NSString * _Nullable)statementDescriptor;
	[Static]
	[Export ("epsParamsWithAmount:name:returnURL:statementDescriptor:")]
	STPSourceParams EpsParamsWithAmount (nuint amount, string name, string returnURL, [NullAllowed] string statementDescriptor);

	// +(STPSourceParams * _Nonnull)multibancoParamsWithAmount:(NSUInteger)amount returnURL:(NSString * _Nonnull)returnURL email:(NSString * _Nonnull)email;
	[Static]
	[Export ("multibancoParamsWithAmount:returnURL:email:")]
	STPSourceParams MultibancoParamsWithAmount (nuint amount, string returnURL, string email);
}

// @interface STPToken : NSObject <STPAPIResponseDecodable, STPSourceProtocol>
[BaseType (typeof(NSObject))]
[DisableDefaultCtor]
interface STPToken : ISTPAPIResponseDecodable, ISTPSourceProtocol
{
	// @property (readonly, nonatomic) NSString * _Nonnull tokenId;
	[Export ("tokenId")]
	string TokenId { get; }

	// @property (readonly, nonatomic) BOOL livemode;
	[Export ("livemode")]
	bool Livemode { get; }

	// @property (readonly, nonatomic) STPTokenType type;
	[Export ("type")]
	STPTokenType Type { get; }

	// @property (readonly, nonatomic) STPCard * _Nullable card;
	[NullAllowed, Export ("card")]
	STPCard Card { get; }

	// @property (readonly, nonatomic) STPBankAccount * _Nullable bankAccount;
	[NullAllowed, Export ("bankAccount")]
	STPBankAccount BankAccount { get; }

	// @property (readonly, nonatomic) NSDate * _Nullable created;
	[NullAllowed, Export ("created")]
	NSDate Created { get; }
}

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern NSString *const _Nonnull StripeDomain;
	[Field ("StripeDomain", "__Internal")]
	NSString StripeDomain { get; }
}

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern NSString *const _Nonnull STPErrorMessageKey;
	[Field ("STPErrorMessageKey", "__Internal")]
	NSString STPErrorMessageKey { get; }

	// extern NSString *const _Nonnull STPCardErrorCodeKey;
	[Field ("STPCardErrorCodeKey", "__Internal")]
	NSString STPCardErrorCodeKey { get; }

	// extern NSString *const _Nonnull STPErrorParameterKey;
	[Field ("STPErrorParameterKey", "__Internal")]
	NSString STPErrorParameterKey { get; }

	// extern NSString *const _Nonnull STPStripeErrorCodeKey;
	[Field ("STPStripeErrorCodeKey", "__Internal")]
	NSString STPStripeErrorCodeKey { get; }

	// extern NSString *const _Nonnull STPStripeErrorTypeKey;
	[Field ("STPStripeErrorTypeKey", "__Internal")]
	NSString STPStripeErrorTypeKey { get; }

	// extern STPCardErrorCode  _Nonnull const STPInvalidNumber;
	[Field ("STPInvalidNumber", "__Internal")]
	NSString STPInvalidNumber { get; }

	// extern STPCardErrorCode  _Nonnull const STPInvalidExpMonth;
	[Field ("STPInvalidExpMonth", "__Internal")]
	NSString STPInvalidExpMonth { get; }

	// extern STPCardErrorCode  _Nonnull const STPInvalidExpYear;
	[Field ("STPInvalidExpYear", "__Internal")]
	NSString STPInvalidExpYear { get; }

	// extern STPCardErrorCode  _Nonnull const STPInvalidCVC;
	[Field ("STPInvalidCVC", "__Internal")]
	NSString STPInvalidCVC { get; }

	// extern STPCardErrorCode  _Nonnull const STPIncorrectNumber;
	[Field ("STPIncorrectNumber", "__Internal")]
	NSString STPIncorrectNumber { get; }

	// extern STPCardErrorCode  _Nonnull const STPExpiredCard;
	[Field ("STPExpiredCard", "__Internal")]
	NSString STPExpiredCard { get; }

	// extern STPCardErrorCode  _Nonnull const STPCardDeclined;
	[Field ("STPCardDeclined", "__Internal")]
	NSString STPCardDeclined { get; }

	// extern STPCardErrorCode  _Nonnull const STPIncorrectCVC;
	[Field ("STPIncorrectCVC", "__Internal")]
	NSString STPIncorrectCVC { get; }

	// extern STPCardErrorCode  _Nonnull const STPProcessingError;
	[Field ("STPProcessingError", "__Internal")]
	NSString STPProcessingError { get; }
}

// @interface Stripe (NSError)
[Category]
[BaseType (typeof(NSError))]
interface NSError_Stripe
{
	// +(NSError * _Nullable)stp_errorFromStripeResponse:(NSDictionary * _Nullable)jsonDictionary;
	[Static]
	[Export ("stp_errorFromStripeResponse:")]
	[return: NullAllowed]
	NSError Stp_errorFromStripeResponse ([NullAllowed] NSDictionary jsonDictionary);
}

// @interface Stripe_Theme (UINavigationBar)
[Category]
[BaseType (typeof(UINavigationBar))]
interface UINavigationBar_Stripe_Theme
{
	// -(void)stp_setTheme:(STPTheme * _Nonnull)theme __attribute__((deprecated("Use the `stp_theme` property.")));
	[Export ("stp_setTheme:")]
	void Stp_setTheme (STPTheme theme);

	// @property (nonatomic, strong) STPTheme * _Nullable stp_theme;
	[NullAllowed, Export ("stp_theme", ArgumentSemantic.Strong)]
	STPTheme Stp_theme { get; set; }
}

[Static]
[Verify (ConstantsInterfaceAssociation)]
partial interface Constants
{
	// extern double StripeVersionNumber;
	[Field ("StripeVersionNumber", "__Internal")]
	double StripeVersionNumber { get; }

	// extern const unsigned char [] StripeVersionString;
	[Field ("StripeVersionString", "__Internal")]
	byte[] StripeVersionString { get; }
}
