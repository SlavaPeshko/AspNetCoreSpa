import { User } from './user';
import { Image } from './image';
import { Like } from './like';

export class Post {
    id: number;
    title: string;
    description: string;
    createAt: string;
    updateAt: string;
    images: Image[];
    user: User;
    countLike: number;
    likes: Like[];
}