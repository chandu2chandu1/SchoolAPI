import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { SchoolModel } from '../models/school.model';
import 'rxjs';

@Injectable()
export class AdminService {

  private readonly _schoolServiceUrl = "http://localhost:51621/api/School";

  constructor(private _http: Http) { }

  getAllSchools(){
    return this._http.get(this._schoolServiceUrl);
  }

  getSchool(schoolId: number) {
    return this._http.get(this._schoolServiceUrl + "/" + schoolId);
  }

  addNewSchool(schoolModel: SchoolModel) {
    return this._http.post(this._schoolServiceUrl, schoolModel);
  }

  updateSchool(schoolModel: SchoolModel) {
    return this._http.put(this._schoolServiceUrl + "/" + schoolModel.Id, schoolModel);
  }

}
