import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"

class VaultsService{

   async getProfileVaults(profileId) {
        const response = await api.get(`api/profiles/${profileId}/vaults`)
        logger.log('getting vaults by profile Id', response.data)
    }

}

export const vaultsService = new VaultsService()