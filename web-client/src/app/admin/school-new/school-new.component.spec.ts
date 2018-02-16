import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SchoolNewComponent } from './school-new.component';

describe('SchoolNewComponent', () => {
  let component: SchoolNewComponent;
  let fixture: ComponentFixture<SchoolNewComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SchoolNewComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SchoolNewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
