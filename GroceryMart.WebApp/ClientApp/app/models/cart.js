"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var cartItem_1 = require("./cartItem");
var globalconfig_1 = require("../services/globalconfig");
var Cart = (function () {
    function Cart(globalConfig) {
        this.globalConfig = globalConfig;
        this.CartName = globalConfig.cartName;
        this.Items = [];
        this.loadCart();
    }
    Cart.prototype.loadCart = function () {
        // console.log(localStorage);
        if (localStorage != null && JSON != null && localStorage[this.CartName] != undefined && localStorage[this.CartName] != "") {
            this.Items = JSON.parse(localStorage[this.CartName]);
            this.calculateCart();
        }
    };
    Cart.prototype.clearCart = function () {
        this.Items = [];
        this.Total = 0;
        if (localStorage != null && JSON != null) {
            localStorage[this.CartName] = '';
        }
        this.TotalItems = 0;
        this.Total = 0;
    };
    ;
    Cart.prototype.saveCart = function () {
        if (localStorage != null && JSON != null) {
            localStorage[this.CartName] = JSON.stringify(this.Items);
        }
    };
    ;
    Cart.prototype.calculateCart = function () {
        var count = 0;
        var price = 0;
        for (var i = 0; i < this.Items.length; i++) {
            var item = this.Items[i];
            count += item.Quantity;
            price += this.Items[i].Total = item.Quantity * item.UnitPrice;
        }
        this.TotalItems = count;
        this.Total = price;
    };
    Cart.prototype.addToCart = function (ProductId, Name, UnitPrice, Quantity) {
        if (Quantity !== undefined) {
            // update Quantity for existing item
            var found = false;
            for (var i = 0; i < this.Items.length && !found; i++) {
                var item = this.Items[i];
                if (item.ProductId === ProductId) {
                    found = true;
                    item.Quantity = item.Quantity + Quantity;
                }
            }
            // new item, add now
            if (!found) {
                var item = new cartItem_1.CartItem(ProductId, Name, UnitPrice, Quantity);
                this.Items.push(item);
            }
            this.calculateCart();
            // save changes
            this.saveCart();
        }
    };
    Cart.prototype.deleteFromCart = function (ProductId) {
        for (var i = 0; i < this.Items.length; i++) {
            var item = this.Items[i];
            if (item.ProductId === ProductId) {
                this.Items.splice(i, 1);
            }
        }
        this.calculateCart();
        // save changes
        this.saveCart();
    };
    Cart.prototype.checkoutPayUmoney = function (user) {
        var params = {
            url: this.globalConfig.paymentGatewayUrl,
            options: {
                key: this.globalConfig.paymentGatewaykey,
                salt: this.globalConfig.paymentGatewaysalt,
                txnid: (Math.random() * 10000000000).toFixed(0),
                amount: this.Total,
                productinfo: this.CartName + '_' + this.Total,
                firstname: user.name,
                email: user.username,
                phone: user.contactNo,
                surl: this.globalConfig.webBaseAddress + '/app/paymentstatus',
                furl: this.globalConfig.webBaseAddress + '/app/paymentstatus',
                service_provider: '',
                hash: '',
                udf1: this.CartId,
                udf2: user.userId
            }
        };
        var str = params.options.key + '|' + params.options.txnid + '|' + params.options.amount + '|' + params.options.productinfo + '|' + params.options.firstname + '|' + params.options.email + '|' + params.options.udf1 + '|' + params.options.udf2 + '|||||||||' + params.options.salt;
        // console.log(str);
        params.options.hash = CryptoJS.SHA512(str).toString();
        //  console.log(params.options.hash);
        // build form
        var form = $('<form/></form>');
        form.attr('action', params.url);
        form.attr('method', 'POST');
        form.attr('style', 'display:none;');
        this.addFormFields(form, params.options);
        $('body').append(form);
        // submit form
        this.clearCart();
        form.submit();
        form.remove();
    };
    // adding hidden fields to form
    Cart.prototype.addFormFields = function (form, data) {
        if (data != null) {
            $.each(data, function (Name, value) {
                if (value != null) {
                    var input = $('<input></input>').attr('type', 'hidden').attr('Name', Name).val(value);
                    form.append(input);
                }
            });
        }
    };
    Cart = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [globalconfig_1.GlobalConfig])
    ], Cart);
    return Cart;
}());
exports.Cart = Cart;
//# sourceMappingURL=cart.js.map