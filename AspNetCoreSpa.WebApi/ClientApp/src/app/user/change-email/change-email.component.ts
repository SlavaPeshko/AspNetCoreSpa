import { Component, OnInit } from '@angular/core';
import { FormControl, Validators, FormGroup } from '@angular/forms';
import { UserService } from '../../services/user.service';
import { Jwt } from '../../helpers/jwt';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-change-email',
  templateUrl: './change-email.component.html',
  styleUrls: ['./change-email.component.css']
})
export class ChangeEmailComponent implements OnInit {
  userId: number;
  currentEmail: string;
  public formGroup: FormGroup;

  constructor(private userService: UserService,
    private jwt: Jwt,
    private authService: AuthService) { 
      this.userId = this.jwt.getUserId();
      this.currentEmail = this.jwt.getEmail();
    }

  ngOnInit(): void {
    this.formGroup = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
    })
  }

  change() {
    if(this.newEmail.errors || this.currentEmail == this.newEmail.value) {
      this.formGroup.markAllAsTouched();
    } else {
      this.userService.changeEmail(this.userId, this.currentEmail, this.newEmail.value)
        .subscribe(data => {
          this.authService.refreshToke();
        });
    }
  }

  get newEmail() {
    return this.formGroup.get('email');
  }

  isSameEmail() {
    return this.currentEmail == this.newEmail.value;
  }
}
