import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentProfileComponentComponent } from './student-profile-component.component';

describe('StudentProfileComponentComponent', () => {
  let component: StudentProfileComponentComponent;
  let fixture: ComponentFixture<StudentProfileComponentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StudentProfileComponentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StudentProfileComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
