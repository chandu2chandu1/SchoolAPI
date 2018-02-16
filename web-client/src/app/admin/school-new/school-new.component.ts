import { Component, OnInit } from '@angular/core';
import { SchoolModel } from '../../models/school.model';

@Component({
  selector: 'app-school-new',
  templateUrl: './school-new.component.html',
  styleUrls: ['./school-new.component.css']
})
export class SchoolNewComponent implements OnInit {

  newSchool = new SchoolModel(0, "", "", "");

  constructor() { }

  ngOnInit() {
  }

  submitData() {
    console.log(this.newSchool);
  }

}
