import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PhoneForgotComponent } from './phone-forgot.component';

describe('PhoneForgotComponent', () => {
  let component: PhoneForgotComponent;
  let fixture: ComponentFixture<PhoneForgotComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PhoneForgotComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PhoneForgotComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
