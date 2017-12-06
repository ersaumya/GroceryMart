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
var http_1 = require("@angular/http");
var Rx_1 = require("rxjs/Rx");
var globalconfig_1 = require("./globalconfig");
var StoreService = (function () {
    function StoreService(config, client) {
        this.config = config;
        this.client = client;
        this.headers = new http_1.Headers({ 'Content-Type': 'application/json;utf8', 'Authorization': 'Basic ' + token });
    }
    StoreService.prototype.GetProducts = function () {
        return this.client.get(this.config.apiAddress + "/store", { headers: this.headers })
            .map(function (res) {
            return res.json();
        })
            .catch(function (err) { return Rx_1.Observable.throw(err); });
    };
    StoreService.prototype.SaveCart = function (cart) {
        return this.client.post(this.config.apiAddress + "/store", JSON.stringify(cart), { headers: this.headers }).catch(function (err) { return Rx_1.Observable.throw(err.json().error); });
    };
    StoreService = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [globalconfig_1.GlobalConfig, http_1.Http])
    ], StoreService);
    return StoreService;
}());
exports.StoreService = StoreService;
//# sourceMappingURL=store.js.map