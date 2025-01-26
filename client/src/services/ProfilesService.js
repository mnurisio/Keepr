import { AppState } from "@/AppState.js"
import { logger } from "@/utils/Logger.js";
import { api } from "./AxiosService.js";
import { Profile } from "@/models/Profile.js";
import { Account } from "@/models/Account.js";

class ProfilesService{

  async getProfileById(profileId) {
        AppState.activeProfile = null
        const response = await api.get(`api/profiles/${profileId}`)
        logger.log('getting profile by Id', response.data)
        const profile = new Profile(response.data)
        AppState.activeProfile = profile
    }



}

export const profilesService = new ProfilesService()