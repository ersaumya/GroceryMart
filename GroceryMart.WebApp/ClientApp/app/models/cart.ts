
import { Injectable } from '@angular/core';
import { CartItem } from './cartItem';
import { GlobalConfig } from '../services/globalconfig';

declare const $: any;
declare const CryptoJS: any;
declare const localStorage: any;

@Injectable()
export class Cart {
    CartId: number;
    Items: any;
    Total: number;
    TotalItems: number;
    UserId: number;
    CreatedDate: string;
    CartName: string;
    constructor(private globalConfig: GlobalConfig) {
        this.CartName = globalConfig.cartName;
        this.Items = [];
        this.loadCart();
}
    loadCart() {
        // console.log(localStorage);
        if (localStorage != null && JSON != null && localStorage[this.CartName] != undefined && localStorage[this.CartName] != "") {
            this.Items = JSON.parse(localStorage[this.CartName]);
            this.calculateCart();
        }
    }
    clearCart() {
        this.Items = [];
        this.Total = 0;
        if (localStorage != null && JSON != null) {
            localStorage[this.CartName] = '';
        }
        this.TotalItems = 0;
        this.Total = 0;
    };

    saveCart() {
        if (localStorage != null && JSON != null) {
            localStorage[this.CartName] = JSON.stringify(this.Items);
        }
    };

    calculateCart() {
        let count = 0;
        let price = 0;
        for (let i = 0; i < this.Items.length; i++) {
            const item = this.Items[i];
            count += item.Quantity;
            price += this.Items[i].Total = item.Quantity * item.UnitPrice;
        }
        this.TotalItems = count;
        this.Total = price;
    }

    addToCart(ProductId: number, Name: string, UnitPrice: number, Quantity: number) {

        if (Quantity !== undefined) {
            // update Quantity for existing item
            let found = false;
            for (let i = 0; i < this.Items.length && !found; i++) {
                const item: CartItem = this.Items[i];
                if (item.ProductId === ProductId) {
                    found = true;
                    item.Quantity = item.Quantity + Quantity;
                }
            }
            // new item, add now
            if (!found) {
                const item = new CartItem(ProductId, Name, UnitPrice, Quantity);
                this.Items.push(item);
            }
            this.calculateCart();
            // save changes
            this.saveCart();
        }
    }

    deleteFromCart(ProductId: number) {
        for (let i = 0; i < this.Items.length; i++) {
            const item = this.Items[i];
            if (item.ProductId === ProductId) {
                this.Items.splice(i, 1);
            }
        }
        this.calculateCart();
        // save changes
        this.saveCart();
    }

    checkoutPayUmoney(user: any) {
        const params = {
            url: this.globalConfig.paymentGatewayUrl,
            options: {
                key: this.globalConfig.paymentGatewaykey,
                salt: this.globalConfig.paymentGatewaysalt,
                txnid: (Math.random() * 10000000000).toFixed(0), // with 10 numbers
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

        const str = params.options.key + '|' + params.options.txnid + '|' + params.options.amount + '|' + params.options.productinfo + '|' + params.options.firstname + '|' + params.options.email + '|' + params.options.udf1 + '|' + params.options.udf2 + '|||||||||' + params.options.salt;

        // console.log(str);
        params.options.hash = CryptoJS.SHA512(str).toString();

        //  console.log(params.options.hash);
        // build form
        const form = $('<form/></form>');
        form.attr('action', params.url);
        form.attr('method', 'POST');
        form.attr('style', 'display:none;');
        this.addFormFields(form, params.options);
        $('body').append(form);

        // submit form
        this.clearCart();

        form.submit();
        form.remove();
    }

    // adding hidden fields to form
    addFormFields(form: any, data: any) {
        if (data != null) {
            $.each(data, function (Name: string, value: string) {
                if (value != null) {
                    const input = $('<input></input>').attr('type', 'hidden').attr('Name', Name).val(value);
                    form.append(input);
                }
            });
        }
    }
}
