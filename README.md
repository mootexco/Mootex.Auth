# Mootex.Auth

Multi-tenant authentication and user management web service.

Mootex.Auth allows you to manage accounts and authentication from a single service, which enables your users to log into many applications or sites using a single pair of credentials. Although assigned roles for each user are stored in the system, Mootex.Auth is not an authorization solution: it just knows which roles a user has, but not what these roles can do on your system. It's up to that system to decide what users can do based on the roles reported by Mootex.Auth.

## Apps

Users of the service may have multiple applications configured. Each application is virtually separated from each other and has independent users. Each app signs and encrypts its tokens with its own keys, which aren't shared amongst apps.

## Usernames and passwords

For the most part, Mootex.Auth is just storing usernames and passwords. They are not validated in any way, so it's the client system's responsibility to do that.

There is a rule regarding usernames: two equal usernames can't exist within an app, but different apps may have the same username.

User's actual password hits the service twice: while creating an account and while authenticating. If you are not comfortable with this then you can send a derivative of the user password or a random string as the user password, and do the mapping with the actual password on your side. Mootex.Auth doesn't care as long as what you send during authentication is the same as what you sent during account creation.

Aside of that, passwords (or whatever you send) are never stored directly. A random, cryptographically secure salt is generated for each account. This salt is added to the actual user's password and the result is hashed with strong hashing algorithms. The resulting data is then encrypted using an external secret that you can configure while hosting Mootex.Auth yourself.

## Other user info

You are free to include additional claims and role names for each user in apps you own. These claims and roles will be added to the generated JWT tokens so you can retrieve them later if you want.

## Generated tokens

Tokens are signed with the app's signing key and encrypted using the app's encrypting key. Tokens contain user claims and role names. The format is base64 encoded, the same as in jwt.io.
