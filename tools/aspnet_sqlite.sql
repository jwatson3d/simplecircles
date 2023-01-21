CREATE TABLE Users (
 pId                                     character(36)           NOT NULL,
 Username                                character varying(255)  NOT NULL,
 ApplicationName                         character varying(255)  NOT NULL,
 Email                                   character varying(128)  NOT NULL,
 Comment                                 character varying(128)  NULL,
 Password                                character varying(255)  NOT NULL,
 PasswordQuestion                        character varying(255)  NULL,
 PasswordAnswer                          character varying(255)  NULL,
 IsApproved                              boolean                 NULL,
 LastActivityDate                        timestamptz             NULL,
 LastLoginDate                           timestamptz             NULL,
 LastPasswordChangedDate                 timestamptz             NULL,
 CreationDate                            timestamptz             NULL,
 IsOnLine                                boolean                 NULL,
 IsLockedOut                             boolean                 NULL,
 LastLockedOutDate                       timestamptz             NULL,
 FailedPasswordAttemptCount              integer                 NULL,
 FailedPasswordAttemptWindowStart        timestamptz             NULL,
 FailedPasswordAnswerAttemptCount        integer                 NULL,
 FailedPasswordAnswerAttemptWindowStart  timestamptz             NULL,
 CONSTRAINT users_pkey PRIMARY KEY (pId),
 CONSTRAINT users_username_application_unique UNIQUE (Username, ApplicationName)
);

CREATE INDEX users_email_index ON Users (Email);
CREATE INDEX users_islockedout_index ON Users (IsLockedOut);

CREATE TABLE Roles (
 Rolename                                character varying(255)  NOT NULL,
 ApplicationName                         character varying(255)  NOT NULL,
 CONSTRAINT roles_pkey PRIMARY KEY (Rolename, ApplicationName)
);

CREATE TABLE UsersInRoles (
 Username                                character varying(255)  NOT NULL,
 Rolename                                character varying(255)  NOT NULL,
 ApplicationName                         character varying(255)  NOT NULL,
 CONSTRAINT usersinroles_pkey PRIMARY KEY (Username, Rolename, ApplicationName),
 CONSTRAINT usersinroles_username_fkey FOREIGN KEY (Username, ApplicationName) REFERENCES Users (Username, ApplicationName) ON DELETE CASCADE,
 CONSTRAINT usersinroles_rolename_fkey FOREIGN KEY (Rolename, ApplicationName) REFERENCES Roles (Rolename, ApplicationName) ON DELETE CASCADE
);

CREATE TABLE Profiles (
 pId                                     character(36)           NOT NULL,
 Username                                character varying(255)  NOT NULL,
 ApplicationName                         character varying(255)  NOT NULL,
 IsAnonymous                             boolean                 NULL,
 LastActivityDate                        timestamptz             NULL,
 LastUpdatedDate                         timestamptz             NULL,
 CONSTRAINT profiles_pkey PRIMARY KEY (pId),
 CONSTRAINT profiles_username_application_unique UNIQUE (Username, ApplicationName),
 CONSTRAINT profiles_username_fkey FOREIGN KEY (Username, ApplicationName) REFERENCES Users (Username, ApplicationName) ON DELETE CASCADE
);

CREATE INDEX profiles_isanonymous_index ON Profiles (IsAnonymous);

CREATE TABLE ProfileData (
 pId                                     character(36)           NOT NULL,
 Profile                                 character(36)           NOT NULL,
 Name                                    character varying(255)  NOT NULL,
 ValueString                             text                    NULL,
 ValueBinary                             bytea                   NULL,
 CONSTRAINT profiledata_pkey PRIMARY KEY (pId),
 CONSTRAINT profiledata_profile_name_unique UNIQUE (Profile, Name),
 CONSTRAINT profiledata_profile_fkey FOREIGN KEY (Profile) REFERENCES Profiles (pId) ON DELETE CASCADE
);

CREATE TABLE Applications (
    ApplicationName         character varying(255)   NOT NULL,
    LoweredApplicationName  character varying(255)   NOT NULL,
    ApplicationId           character(36)            NOT NULL,
    Description             character varying(255),
    CONSTRAINT applications_pkey PRIMARY KEY (ApplicationId),
    CONSTRAINT applications_application_name_unique UNIQUE (ApplicationName),
    CONSTRAINT applications_loweredapplication_name_unique UNIQUE (LoweredApplicationName)
);
CREATE INDEX applications_index ON Applications(LoweredApplicationName);
