import { Component, OnInit } from '@angular/core';
import { AdminService } from '../../services/admin.service';
import { SchoolModel } from '../../models/school.model';
import 'rxjs';

@Component({
  selector: 'app-school-info',
  templateUrl: './school-info.component.html',
  styleUrls: ['./school-info.component.css']
})
export class SchoolInfoComponent implements OnInit {

  schoolList: SchoolModel[] = [];
  constructor(private _adminServices: AdminService) { }

  ngOnInit() {
    this.getAllSchools();
  }

  getAllSchools() {
    this._adminServices.getAllSchools().subscribe(
      response => this.schoolList = response.json()
    );
  }
}
