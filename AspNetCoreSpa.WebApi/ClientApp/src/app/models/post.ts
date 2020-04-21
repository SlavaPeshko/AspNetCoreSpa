import { User } from './user';
import { Image } from './image';

export class Post {
    id: string;
    title: string;
    description: string;
    createAt: string;
    updateAt: string;
    images: Image[];
    user: User;
}