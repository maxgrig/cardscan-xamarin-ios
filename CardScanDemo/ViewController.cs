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
            for (int i = 4; i < cardNumber.Length; i += 4)
            {
                cardNumber = cardNumber.Insert(i + i / 4 - 1, " ");
            }

            lblCardNumber.Text = cardNumber;
            lblExpiryDate.Text = $"{creditCard?.ExpiryMonth}/{creditCard?.ExpiryYear}".Trim('/');

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