﻿using System;
using System.Threading.Tasks;
using Abp;
using Abp.Authorization;
using Abp.Authorization.Users;
using Abp.Configuration;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Organizations;
using Abp.Runtime.Caching;
using Abp.Threading;
using Abp.Zero.Configuration;
using MyCompanyName.AbpZeroTemplate.Authorization.Roles;
using MyCompanyName.AbpZeroTemplate.MultiTenancy;
using Abp.Localization;
using Abp.IdentityFramework;

namespace MyCompanyName.AbpZeroTemplate.Authorization.Users {
    /// <summary>
    /// User manager.
    /// Used to implement domain logic for users.
    /// Extends <see cref="AbpUserManager{TTenant,TRole,TUser}"/>.
    /// </summary>
    public class UserManager : AbpUserManager<Role, User> {
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public UserManager(
          UserStore userStore, RoleManager roleManager,
          IPermissionManager permissionManager, IUnitOfWorkManager unitOfWorkManager, ICacheManager cacheManager,
          IRepository<OrganizationUnit, long> organizationUnitRepository, IRepository<UserOrganizationUnit, long> userOrganizationUnitRepository, IOrganizationUnitSettings organizationUnitSettings, ILocalizationManager localizationManager, IdentityEmailMessageService emailService, ISettingManager settingManager, IUserTokenProviderAccessor userTokenProviderAccessor
)
           : base(
                userStore, roleManager,
           permissionManager, unitOfWorkManager, cacheManager,
           organizationUnitRepository, userOrganizationUnitRepository,
            organizationUnitSettings, localizationManager, emailService, settingManager, userTokenProviderAccessor
) {

            _unitOfWorkManager = unitOfWorkManager;
        }

        public async Task<User> GetUserOrNullAsync(UserIdentifier userIdentifier) {
            using (_unitOfWorkManager.Begin()) {
                using (_unitOfWorkManager.Current.SetTenantId(userIdentifier.TenantId)) {
                    return await FindByIdAsync(userIdentifier.UserId);
                }
            }
        }

        public User GetUserOrNull(UserIdentifier userIdentifier) {
            return AsyncHelper.RunSync(() => GetUserOrNullAsync(userIdentifier));
        }

        public async Task<User> GetUserAsync(UserIdentifier userIdentifier) {
            var user = await GetUserOrNullAsync(userIdentifier);
            if (user == null) {
                throw new ApplicationException("There is no user: " + userIdentifier);
            }

            return user;
        }

        public User GetUser(UserIdentifier userIdentifier) {
            return AsyncHelper.RunSync(() => GetUserAsync(userIdentifier));
        }
    }

  

}