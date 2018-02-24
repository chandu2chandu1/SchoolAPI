import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SchoolModel } from '../../models/school.model';
import { AdminService } from '../../services/admin.service';
import { Form } from '@angular/forms';

@Component({
  selector: 'app-edit-school',
  templateUrl: './edit-school.component.html',
  styleUrls: ['./edit-school.component.css']
})
export class EditSchoolComponent implements OnInit {

  editableSchool: SchoolModel = {
    SchoolId: 0,
    Address: "",
    SchoolLogo: "",
    SchoolName:""
  };

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private adminService:AdminService) { }

  ngOnInit() {
    this.route.params.subscribe(
      params => this.getSchool(params.id)
    );
  }

  getSchool(schoolID: number) {
    if (schoolID > 0) {
      this.adminService.getSchool(schoolID).subscribe(
        data => this.editableSchool = data.json()
      )
    }
  }

  goBack() {
    this.router.navigate(["../SchoolInfo"]);
  }

  SubmitForm() {
    this.adminService.updateSchool(this.editableSchool).subscribe(
      response => console.log(response)
    );
  }

}
