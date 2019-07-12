using CardScanBinding;
using System;
using UIKit;

namespace CardScanDemo
{
    public partial class ViewController : UIViewController, IScanDelegate
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
           
            btnScan.TouchUpInside += BtnScan_TouchUpInside;
        }

        private void BtnScan_TouchUpInside(object sender, EventArgs e)
        {
            lblCardNumber.Text = " ";
            lblExpiryDate.Text = " ";

            var vc = ScanViewController.CreateViewControllerWithDelegate(this);
            PresentViewController(vc, true, null);
        }

        public void UserDidScanCard(ScanViewController scanViewController, CreditCard creditCard)
        {
            var cardNumber = creditCard?.Number ?? "";
            if (cardNumber.Length == 16)
            {
                cardNumber = cardNumber.Insert(12, "  ").Insert(8, "  ").Insert(4, "  ");
            }
            else if (cardNumber.Length == 15 ||
                     cardNumber.Length == 14)
            {
                cardNumber = cardNumber.Insert(10, "  ").Insert(4, "  ");
            }

            lblCardNumber.Text = cardNumber;

            if (!string.IsNullOrEmpty(creditCard.ExpiryMonth) && !string.IsNullOrEmpty(creditCard.ExpiryYear))
            {
                lblExpiryDate.Text = $"{creditCard?.ExpiryMonth}/{creditCard?.ExpiryYear}".Trim('/');
            }
            else
            {
                lblExpiryDate.Text = "n/a";
            }

            DismissViewController(true, null);
        }

        public void UserDidCancel(ScanViewController scanViewController)
        {
            DismissViewController(true, null);
        }

        public void UserDidSkip(ScanViewController scanViewController)
        {
            DismissViewController(true, null);
        }
    }
}