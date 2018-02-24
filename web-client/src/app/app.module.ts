import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { MainMenuComponent } from './main-menu/main-menu.component';
import { SchoolInfoComponent } from './admin/school-info/school-info.component';
import { AdminService } from './services/admin.service';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { SchoolNewComponent } from './admin/school-new/school-new.component';
import { DropdownDirective } from './shared/dropdown.directive';
import { EditSchoolComponent } from './admin/edit-school/edit-school.component';

const appRoutes: Routes = [{
  path: 'SchoolInfo',
  component: SchoolInfoComponent
},
  {
    path: 'newschool',
    component: SchoolNewComponent
  },
  {
    path: "school/edit/:id",
    component:EditSchoolComponent
  }
]

@NgModule({
  declarations: [
    AppComponent,
    MainMenuComponent,
    SchoolInfoComponent,
    SchoolNewComponent,
    DropdownDirective,
    EditSchoolComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot(appRoutes)
  ],
  providers: [ AdminService ],
  bootstrap: [AppComponent]
})
export class AppModule { }
