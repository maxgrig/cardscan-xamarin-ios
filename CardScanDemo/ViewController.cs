using CardScanBinding;
using Foundation;
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
            var vc = ScanViewController.CreateViewControllerWithDelegate(this);
            var c = ScanViewController.IsCompatible;
            //ScanViewController
            PresentViewController(vc, true, null);
        }
            
        public void UserDidCancel(ScanViewController scanViewController)
        {
           
        }

        public void UserDidScanCard(ScanViewController scanViewController, CreditCard creditCard)
        {
            
        }

        public void UserDidSkip(ScanViewController scanViewController)
        {
            
        }
    }
}