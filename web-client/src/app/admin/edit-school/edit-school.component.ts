import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { SchoolModel } from '../../models/school.model';
import { AdminService } from '../../services/admin.service';
import { Form, NgForm } from '@angular/forms';
import 'rxjs';

@Component({
  selector: 'app-edit-school',
  templateUrl: './edit-school.component.html',
  styleUrls: ['./edit-school.component.css']
})
export class EditSchoolComponent implements OnInit {

  editableSchool: SchoolModel = new SchoolModel(0, "", "", "");
  @ViewChild('f') schoolForm: NgForm;
  hasErrorFetching: boolean = false;

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
    this.hasErrorFetching = false;
    if (schoolID > 0) {
      this.adminService.getSchool(schoolID).subscribe(
        data => this.editableSchool = data.json(),
        error => {
          if (error.status == 404) {
            this.hasErrorFetching = true;
          }
        }
      )
    }
    else
      this.hasErrorFetching = true;  
  }

  Cancel() {
    if (this.schoolForm.dirty) {
      if (confirm("Any modifications made wont be saved.  Do you want to cancel."))
        this.router.navigate(["../SchoolInfo"]);
    }
    else
      this.router.navigate(["../SchoolInfo"]);
   }

  SubmitForm() {
    this.adminService.updateSchool(this.editableSchool).subscribe(
      response => console.log(response)
    );
  }

}
