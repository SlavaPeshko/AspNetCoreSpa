import { Component, OnInit, Inject } from '@angular/core';
import { UserService } from '../../services/user.service';
import { User } from '../../models/user';
import { Jwt } from '../../helpers/jwt';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  public user: User;
  public isMale: boolean = false;
  public isFemale: boolean = false;
  female: string = 'Female';
  male: string = 'Male';

  constructor(private userService: UserService, private jwt: Jwt) {
   }

  ngOnInit() {
    const userId: string = this.jwt.getUserId();
    this.userService.getUser(userId).subscribe(data => {
      this.user = data;
      this.isFemale = this.user.gender === this.female;
      this.isMale = this.user.gender === this.male;
    });
  }

  public save() {
    console.log(this.user);
  }

  onItemChange(item){
    debugger;
    item = !item;
  }
}
