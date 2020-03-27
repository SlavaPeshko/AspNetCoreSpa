import { Country } from '../models/country';
import { Gender } from '../models/gender';

export class User {
    id: string;
    email: string;
    phone: string;
    firstName: string;
    lastName: string;
    birthDay: string;
    gender: Gender;
    countryName: string;
    country: Country;
}