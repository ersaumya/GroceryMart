"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var GlobalConfig = (function () {
    function GlobalConfig() {
        this.apiAddress = 'http://localhost:41024//api';
        this.webBaseAddress = 'http://localhost:33610';
        this.paymentGatewayUrl = 'https://test.payu.in/_payment';
        this.paymentGatewaykey = 'gtKFFx';
        this.paymentGatewaysalt = 'eCwWELxi';
        this.cartName = 'MyCart';
    }
    GlobalConfig = __decorate([
        core_1.Injectable()
    ], GlobalConfig);
    return GlobalConfig;
}());
exports.GlobalConfig = GlobalConfig;
//# sourceMappingURL=globalconfig.js.map