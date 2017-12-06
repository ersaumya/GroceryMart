import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import { GlobalConfig } from './globalconfig';
import { Product } from '../models/product';
declare const token: any;

@Injectable()
export class StoreService {
    headers: Headers;
    constructor(private config: GlobalConfig, private client: Http) {

        this.headers = new Headers({ 'Content-Type': 'application/json;utf8', 'Authorization': 'Basic ' + token });
    }
    GetProducts(): Observable<Product[]> {
        return this.client.get(this.config.apiAddress + "/store", { headers: this.headers })
            .map((res) => {
                return res.json();
            })
            .catch((err) => Observable.throw(err));
    }
    SaveCart(cart: any): Observable<Response> {
        return this.client.post(this.config.apiAddress + "/store", JSON.stringify(cart), { headers: this.headers }).catch((err: any) => Observable.throw(err.json().error));
    }
}
