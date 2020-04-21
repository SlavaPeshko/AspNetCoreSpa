using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreSpa.Contracts.QueryRepositories;
using AspNetCoreSpa.Contracts.QueryRepositories.Dto;
using AspNetCoreSpa.Data.QueryRepository.Base;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace AspNetCoreSpa.Data.QueryRepository
{
    public class PostQueryRepository : QueryRepositoryBase, IPostQueryRepository
    {
        public PostQueryRepository(IConfiguration config) : base(config)
        {
        }

        public async Task<IEnumerable<PostDto>> GetPagePostsAsync(PostPageFiltersDto filtersDto)
        {
            using (IDbConnection connection = Connection)
            {
                string query = @"SELECT ps.[Id] PostId, ps.[Title], ps.[Description] PostDescription, ps.[CreateAt] PostCreateAt, ps.[UpdateAt] PostUpdateAt,
                                    cm.[Id] CommentId, cm.[Description] CommentDescription, cm.[CreateAt] CommentCreateAt, cm.[UpdateAt] CommentUpdateAt,
                                    u.[Email], i.[Path], i.[Name], i.[UserId], i.[PostId]
                                    FROM (SELECT * FROM [AspNetCoreSpa].[dbo].[Posts] ORDER BY [CreateAt] DESC OFFSET @Limit * (@Offset - 1)  ROWS FETCH NEXT @Limit ROWS ONLY) ps
                                    LEFT JOIN [AspNetCoreSpa].[dbo].[Comments] AS cm ON cm.[PostId] = ps.[Id]
									LEFT JOIN [AspNetCoreSpa].[dbo].[Images] AS i ON i.[PostId] = ps.[Id] OR i.[UserId] = ps.[UserId]
									JOIN [AspNetCoreSpa].[dbo].[Users] AS u ON u.[Id] = ps.[UserId]";

                var postDtoDictionary = new Dictionary<Guid, PostDto>();

                var list = await connection.QueryAsync<PostDto, CommentDto, UserDto, ImageDto, PostDto>(
                    query,
                    (postDto, commentDto, userDto, imageDto) =>
                    {
                        PostDto postDtoEntry;
                        if (!postDtoDictionary.TryGetValue(postDto.PostId, out postDtoEntry))
                        {
                            postDtoEntry = postDto;
                            postDtoEntry.Comments = new List<CommentDto>();
                            postDtoEntry.Images = new List<ImageDto>();
                            postDtoEntry.User = new UserDto();
                            postDtoDictionary.Add(postDtoEntry.PostId, postDtoEntry);
                        }

                        if(commentDto != null)
                            postDtoEntry.Comments.Add(commentDto);
                        
                        // Images of posts
                        if(imageDto?.PostId != null)
                            postDtoEntry.Images.Add(imageDto);

                        if (userDto == null) return postDtoEntry;

                        postDtoEntry.User.Email = userDto.Email;
                        
                        if (imageDto?.UserId != null)
                            postDtoEntry.User.ImageDto = new ImageDto {Name = imageDto.Name, Path = imageDto.Path};

                        return postDtoEntry;
                    },
                    new { Limit = filtersDto.ItemsPerPage, Offset = filtersDto.PageNumber },
                    splitOn: "PostUpdateAt, CommentId, Email, Path");

                return list.Distinct();
            }
        }

        public async Task<PostDto> GetPostByIdAsync(Guid id)
        {
            using (IDbConnection connection = Connection)
            {
                string query = @"SELECT [Id], [Description], [CreateAt], [UpdateAt], [UserId]
                                   FROM [AspNetCoreSpa].[dbo].[Posts]  WHERE [Id] = @Id";

                return await connection.QueryFirstOrDefaultAsync<PostDto>(query, new { Id = id });
            }
        }
    }
}