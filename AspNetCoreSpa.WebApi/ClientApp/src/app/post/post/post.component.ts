import { Input, Component, OnInit } from '@angular/core';
import { Post } from 'src/app/models/post';
import { LikeService } from '../../services/like.service';
import { Jwt } from '../../helpers/jwt';

import * as moment from 'moment';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {
  @Input() post: Post;
  isActiveLike: boolean = false;
  isActiveDislike: boolean = false;

  constructor(private likeService: LikeService,
    private jwt: Jwt) { }

  ngOnInit(): void {
  }

  timeSince(date: string) {
    return moment(date).fromNow();
  }

  like(postId: number, isLike: boolean) {
    this.likeService.createLike(postId, isLike).subscribe(data => {
      this.post.countLike = data;
    });
  }

  belongLikeUser(isLike: boolean) {
    const currentUserId = this.jwt.getUserId();
    if(!currentUserId)
      return false;

    return this.post.likes.some(x => x.isLike == isLike && x.userId == currentUserId);
  }
}
