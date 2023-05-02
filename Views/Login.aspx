<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="OnlineBookShop.Views.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../Assets/Lib/css/bootstrap.min.css" />
</head>
<body>

    <div class="container-fluid">
        <div class="row mt-5 mb-5">
        </div>
        <div class="row">
            <div class="col-md-4">
            </div>
            <div class="col">
                <form id="form1" runat="server">
                    <div>
                        <div class="row">
                            <h3 style="font-family: Poppins; color: brown;"><b>Book Shop Managing Application</b></h3>
                            <div class="col-md-4">
                            </div>
                            <div class="col-md-8">
                                <img src="../Assets/Images/cart.png" style="height:100px; width:100px"  />
                            </div>
                        </div>
                    </div>
        <div class="mt-3">
            <label for="" class="col-form-label" style="font-family: Poppins;" ><h3><b>User Email</b></h3></label>
            <input type="email" placeholder="Your Email" autocomplete="off" class="form-control" id="UnameTb"  runat="server"/>
        </div>
         <div class="mt-3">
            <label for="" class="col-form-label"  style="font-family: Poppins;" ><h3><b>Password</b></h3</label>
            <input type="password" placeholder="Password" autocomplete="off" class="form-control" id="PasswordTb" runat="server" />
        </div>
                    <div class="mt-3 d-block">
                         <asp:Label runat="server" ID="ErrMsg" class="text-danger text-center"></asp:Label><br/>
                        <asp:Button Text="Login" runat="server" class="btn-success btn" ID="LoginBtn" OnClick="LoginBtn_Click" />
                    </div>
                   

    </form>
            </div>
            <div class="col-md-4">

            </div>
        </div>
    </div>
    
</body>
</html>
