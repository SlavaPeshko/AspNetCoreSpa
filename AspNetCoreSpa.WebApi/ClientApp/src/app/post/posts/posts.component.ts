import { Component, OnInit } from '@angular/core';
import { PostService } from '../../services/post.service';
import { Post } from 'src/app/models/post';

@Component({
  selector: 'app-posts',
  templateUrl: './posts.component.html',
  styleUrls: ['./posts.component.css']
})
export class PostsComponent implements OnInit {
  posts: Post[] = [];


  constructor(private postService: PostService) { }

  ngOnInit(): void {
    this.postService.getByPageItems(1, 10).subscribe(data => {
      this.posts = data;
      console.log(this.posts);
    });
  }

  imagePost(postIndex: number, imageIndex: number) {
    return this.posts[postIndex].images[imageIndex].url;
  }

  request() {

  }
}
