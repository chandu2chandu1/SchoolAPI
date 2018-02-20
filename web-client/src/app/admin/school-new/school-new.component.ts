import { Component, OnInit } from '@angular/core';
import { SchoolModel } from '../../models/school.model';
import { AdminService } from '../../services/admin.service';

@Component({
  selector: 'app-school-new',
  templateUrl: './school-new.component.html',
  styleUrls: ['./school-new.component.css']
})
export class SchoolNewComponent implements OnInit {

  newSchool = new SchoolModel(0, "", "", "");

  constructor(private _adminService:AdminService) { }

  ngOnInit() {
  }

  submitData() {
    console.log(this.newSchool);
    this._adminService.addNewSchool(this.newSchool)
      .subscribe(response => {
        console.log(response.json());
    })
  }

}
