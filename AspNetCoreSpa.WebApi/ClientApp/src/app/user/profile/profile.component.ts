import { Component, OnInit, Inject } from '@angular/core';
import { UserService } from '../../services/user.service';
import { CountryService } from '../../services/country.service';
import { User } from '../../models/user';
import { Country } from '../../models/country';
import { Jwt } from '../../helpers/jwt';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  public countries: Country[];
  public selectedCountryName: Country;
  public user: User;
  public isMale: boolean = false;
  public isFemale: boolean = false;
  female: string = 'Female';
  male: string = 'Male';

  constructor(private userService: UserService,
     private jwt: Jwt,
     private countryService: CountryService) {
   }

  ngOnInit() {
    const userId: string = this.jwt.getUserId();

    this.userService.getUser(userId).subscribe(data => {
      this.user = data;
      this.isFemale = this.user.gender === this.female;
      this.isMale = this.user.gender === this.male;
    });

    this.countryService.getCountries().subscribe(data => {
      this.countries = data;
    })

  }

  public save() {
    console.log(this.selectedCountryName);
  }

  onItemChange(item){
    debugger;
    item = !item;
  }

  updateWorkout(event){
    debugger;
    this.user.country = this.countries.find(x => x.name === event);
  }
}
