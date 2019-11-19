var OidcSettings = {    
    authority: 'http://localhost:5000/',
    client_id: 'reactoidc',
    redirect_uri: 'http://localhost:3000/callback.html',    
    response_type: 'id_token token',
    scope: 'openid profile email',
    post_logout_redirect_uri:  'https://localhost:3000//login-callback',
};

export default OidcSettings;