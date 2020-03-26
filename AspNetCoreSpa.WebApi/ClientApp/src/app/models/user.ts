import { Country } from '../models/country';

export class User {
    id: string;
    email: string;
    phone: string;
    firstName: string;
    lastName: string;
    birthDay: string;
    gender: string;
    countryName: string;
    country: Country;
}