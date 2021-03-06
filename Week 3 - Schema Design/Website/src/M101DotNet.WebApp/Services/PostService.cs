﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M101DotNet.WebApp.Models;
using M101DotNet.WebApp.Repositories;
using M101DotNet.WebApp.Models.Account;
using MongoDB.Bson;
using System.Web.Mvc;

namespace M101DotNet.WebApp.Services
{
    public class PostService : IPostService
    {
        #region Protected Properties

        private IPostRepository _postRepository;

        #endregion

        #region PostService() Constructor

        /// <summary>
        /// 
        /// </summary>
        public PostService(/*IPostRepository postRepository*/)
        {
            // _postRepository = new PostRepository();  // OLD line without using StructureMap

            _postRepository = DependencyResolver.Current.GetService<IPostRepository>();  // Creating dependency here directly instead of using the constructor parameter
            
            // _postRepository = postRepository;  // This would make use of the constructor parameters and enable Dependency Injection via the constructor
        }

        #endregion

        #region GetRecentPosts

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Post>> GetRecentPosts()
        {
            var listOfRecentPosts = await _postRepository.GetRecentPosts();

            return listOfRecentPosts;
        }

        #endregion

        #region InsertNewPost

        /// <summary>
        /// 
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        public async Task<Post> InsertNewPost(Post post)
        {
            var result = await _postRepository.InsertNewPost(post);

            return result;
        }

        #endregion

        #region FindPost

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Post> FindPost(ObjectId id)
        {
            var result = await _postRepository.FindPost(id);

            return result;
        }

        #endregion

        #region FindPostsByTag

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        public async Task<List<Post>> FindPostsByTag(string tag)
        {
            var listOfPosts = await _postRepository.FindPostsByTag(tag);

            return listOfPosts;
        }

        #endregion

        #region AddCommentToPost

        /// <summary>
        /// 
        /// </summary>
        /// <param name="comment"></param>
        /// <param name="postId"></param>
        /// <returns></returns>
        public async Task<Post> AddCommentToPost(Comment comment, ObjectId postId)
        {
            var post = await _postRepository.AddCommentToPost(comment, postId);

            return post;
        }

        #endregion

    }
}
