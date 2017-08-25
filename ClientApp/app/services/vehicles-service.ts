import { Feature } from './../../models/feature';
import { Injectable } from "@angular/core";
import { Http } from "@angular/http";
import { Observable } from "rxjs/Observable";
import 'rxjs/add/operator/map';
import { Make } from "../../models/make";

@Injectable()
export class VehiclesService {
    constructor(private _http: Http) {}

    getMakes() : Observable<Array<Make>> {
        return this._http.get('api/vehicles/makes')
            .map(res => res.json());
    }

    getFeatures() : Observable<Array<Feature>> {
        return this._http.get('api/vehicles/features')
            .map(res => res.json());
    }
}