import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

@Injectable()
export class AdminService {

  readonly _schoolServiceUrl = "http://localhost:51621/api/School";

  constructor(private _http: Http) { }

  getAllSchools(){
    return this._http.get(this._schoolServiceUrl);
  }

}
