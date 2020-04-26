import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CreatePostComponent } from './create-post/create-post.component';
import { PostsComponent } from './posts/posts.component';
import { PostComponent } from './post/post.component';



@NgModule({
  declarations: [CreatePostComponent, PostsComponent, PostComponent],
  imports: [
    CommonModule,
    FormsModule
  ]
})
export class PostModule { }
