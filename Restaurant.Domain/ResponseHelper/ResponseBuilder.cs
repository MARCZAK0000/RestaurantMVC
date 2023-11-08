using Microsoft.AspNetCore.Identity;

namespace Restaurant.Domain.ResponseHelper
{

    public class ResponseBuilder
    {
        private Response _response = new Response();


        public Response Build()
        {
            return _response;
        }

        public ResponseBuilder SetResult(bool item)
        {
            _response.Result = item;
            return this;
        }

        public ResponseBuilder SetConfirmationEmailToken(string emailToken)
        {
            _response.ConfirmationToken = emailToken;
            return this;
        }

        public ResponseBuilder SetUserId(string userId) 
        {
            _response.UserId = userId;
            return this;
        }
        public ResponseBuilder SetMessage(string message) 
        {
            _response.Message = message;
            return this;    
        }
    }

}
