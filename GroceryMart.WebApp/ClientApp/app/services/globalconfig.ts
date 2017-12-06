
import { Injectable } from '@angular/core';

@Injectable()
export class GlobalConfig {
    apiAddress = 'http://localhost:41024//api';
    webBaseAddress = 'http://localhost:33610';

    paymentGatewayUrl = 'https://test.payu.in/_payment';
    paymentGatewaykey = 'gtKFFx';
    paymentGatewaysalt = 'eCwWELxi';
    cartName = 'MyCart';
}
