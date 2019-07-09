using System;
using System.Runtime.InteropServices;
using ObjCRuntime;

[Native]
public enum STPShippingType : nuint
{
	Shipping,
	Delivery
}

[Native]
public enum STPShippingStatus : nuint
{
	Valid,
	Invalid
}

[Native]
public enum STPPaymentStatus : nuint
{
	Success,
	Error,
	UserCancellation
}

[Native]
public enum STPFilePurpose : nint
{
	IdentityDocument,
	DisputeEvidence,
	Unknown
}

[Native]
public enum STPBillingAddressFields : nuint
{
	None,
	Zip,
	Full,
	Name
}

[Native]
public enum STPPaymentOptionType : nuint
{
	None = 0,
	ApplePay = 1 << 0,
	All = ApplePay
}

static class CFunctions
{
	// extern void linkSTPAPIClientApplePayCategory ();
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern void linkSTPAPIClientApplePayCategory ();

	// extern void linkNSErrorCategory ();
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern void linkNSErrorCategory ();

	// extern void linkUINavigationBarThemeCategory ();
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern void linkUINavigationBarThemeCategory ();
}

[Native]
public enum STPBankAccountHolderType : nint
{
	Individual,
	Company
}

[Native]
public enum STPBankAccountStatus : nint
{
	New,
	Validated,
	Verified,
	VerificationFailed,
	Errored
}

[Native]
public enum STPCardBrand : nint
{
	Visa,
	Amex,
	MasterCard,
	Discover,
	Jcb,
	DinersClub,
	UnionPay,
	Unknown
}

[Native]
public enum STPCardFundingType : nint
{
	Debit,
	Credit,
	Prepaid,
	Other
}

[Native]
public enum STPCardValidationState : nint
{
	Valid,
	Invalid,
	Incomplete
}

[Native]
public enum STPPaymentIntentStatus : nint
{
	Unknown,
	RequiresPaymentMethod,
	RequiresSource = RequiresPaymentMethod,
	RequiresConfirmation,
	RequiresAction,
	RequiresSourceAction = RequiresAction,
	Processing,
	Succeeded,
	RequiresCapture,
	Canceled
}

[Native]
public enum STPPaymentIntentCaptureMethod : nint
{
	Unknown,
	Automatic,
	Manual
}

[Native]
public enum STPPaymentIntentConfirmationMethod : nint
{
	Unknown,
	Publishable,
	Secret
}

[Native]
public enum STPPaymentIntentActionType : nuint
{
	Unknown,
	RedirectToURL
}

[Native]
public enum STPPaymentIntentSourceActionType : nuint
{
	Unknown = STPPaymentIntentActionTypeUnknown,
	AuthorizeWithURL = STPPaymentIntentActionTypeRedirectToURL
}

[Native]
public enum STPPaymentMethodType : nuint
{
	Card,
	iDEAL,
	CardPresent,
	Unknown
}

[Native]
public enum STPPaymentMethodCardCheckResult : nuint
{
	Pass,
	Failed,
	Unavailable,
	Unchecked,
	Unknown
}

[Native]
public enum STPPaymentMethodCardWalletType : nuint
{
	AmexExpressCheckout,
	ApplePay,
	GooglePay,
	Masterpass,
	SamsungPay,
	VisaCheckout,
	Unknown
}

[Native]
public enum STPRedirectContextState : nuint
{
	NotStarted,
	InProgress,
	Cancelled,
	Completed
}

[Native]
public enum STPSourceCard3DSecureStatus : nint
{
	Required,
	Optional,
	NotSupported,
	Unknown
}

[Native]
public enum STPSourceFlow : nint
{
	None,
	Redirect,
	CodeVerification,
	Receiver,
	Unknown
}

[Native]
public enum STPSourceUsage : nint
{
	Reusable,
	SingleUse,
	Unknown
}

[Native]
public enum STPSourceStatus : nint
{
	Pending,
	Chargeable,
	Consumed,
	Canceled,
	Failed,
	Unknown
}

[Native]
public enum STPSourceType : nint
{
	Bancontact,
	Card,
	Giropay,
	Ideal,
	SEPADebit,
	Sofort,
	ThreeDSecure,
	Alipay,
	P24,
	Eps,
	Multibanco,
	Unknown
}

[Native]
public enum STPSourceRedirectStatus : nint
{
	Pending,
	Succeeded,
	Failed,
	Unknown
}

[Native]
public enum STPSourceVerificationStatus : nint
{
	Pending,
	Succeeded,
	Failed,
	Unknown
}

[Native]
public enum STPTokenType : nint
{
	Account = 0,
	BankAccount,
	Card,
	Pii,
	CVCUpdate
}

[Native]
public enum STPErrorCode : nint
{
	ConnectionError = 40,
	InvalidRequestError = 50,
	APIError = 60,
	CardError = 70,
	CancellationError = 80,
	EphemeralKeyDecodingError = 1000
}
