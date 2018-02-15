import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import { AppComponent } from './app.component';
import { MainMenuComponent } from './main-menu/main-menu.component';
import { SchoolInfoComponent } from './admin/school-info/school-info.component';


@NgModule({
  declarations: [
    AppComponent,
    MainMenuComponent,
    SchoolInfoComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
