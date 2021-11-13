using Blog.NETCore.Application.Response;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.NETCore.Application.Functions.Comments.Commands.CreateComment
{
	public class CreatedCommentCommandResponse : BaseResponse
	{
		public int? CommentId { get; set; }

		public CreatedCommentCommandResponse() : base()
		{
		}
		public CreatedCommentCommandResponse(string message) : base(message)
		{
		}
		public CreatedCommentCommandResponse(string message, bool success) : base(message, success)
		{
		}
		public CreatedCommentCommandResponse(ValidationResult validationResult) : base(validationResult)
		{
		}
		public CreatedCommentCommandResponse(int commentId)
		{ 
			CommentId = commentId;
		}
	}
}
