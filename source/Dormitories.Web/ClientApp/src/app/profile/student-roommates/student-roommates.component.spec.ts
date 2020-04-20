import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentRoommatesComponent } from './student-roommates.component';

describe('StudentRoommatesComponent', () => {
  let component: StudentRoommatesComponent;
  let fixture: ComponentFixture<StudentRoommatesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StudentRoommatesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StudentRoommatesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
