import { Input, Component, OnInit } from '@angular/core';
import { Post } from 'src/app/models/post';
import { LikeService } from '../../services/like.service';
import { PostService } from '../../services/post.service';
import { Jwt } from '../../helpers/jwt';

import * as moment from 'moment';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {
  @Input() post: Post;
  userId: number;

  constructor(private likeService: LikeService,
    private postService: PostService,
    private jwt: Jwt) {
      this.userId = this.jwt.getUserId();
    }

  ngOnInit(): void {
  }

  timeSince(date: string) {
    return moment(date).fromNow();
  }

  like(like: boolean) {
    // if has like or dislike of user
    if((this.hasLike() && like) || (this.hasDislike() && !like)) {
      this.deleteLike(() => this.getRating())
      return;
    }

    if(this.post.likes.length == 1) {
      this.deleteLike(() => this.creteLike(like));
      return;
    }

    this.creteLike(like);
  }

  hasLike() {
    return this.post.likes.some(x => x.isLike)
  }

  hasDislike() {
    return this.post.likes.some(x => !x.isLike)
  }

  private creteLike(like: boolean) {
    this.likeService.createLike(this.post.id, like).subscribe((data: any) => {
      this.post.likes.push(data);
      this.getRating();
    });
  }

  private deleteLike(func: () => void) {
    return this.likeService.deleteLike(this.post.likes[0].id).subscribe(data => {
      this.post.likes = [];
      func();
    });
  }

  private getRating() {
    this.postService.getRating(this.post.id).subscribe((data: number) => {
      this.post.countLike = data;
    });
  }
}
