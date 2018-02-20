import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { SchoolModel } from '../models/school.model';

@Injectable()
export class AdminService {

  private readonly _schoolServiceUrl = "http://localhost:51621/api/School";

  constructor(private _http: Http) { }

  getAllSchools(){
    return this._http.get(this._schoolServiceUrl);
  }

  addNewSchool(schoolModel: SchoolModel) {
    return this._http.post(this._schoolServiceUrl, schoolModel);
  }

}
