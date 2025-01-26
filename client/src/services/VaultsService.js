import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { AppState } from "@/AppState.js"
import { Vault } from "@/models/Vault.js"

class VaultsService{

   async getProfileVaults(profileId) {
        AppState.profileVaults = []
        const response = await api.get(`api/profiles/${profileId}/vaults`)
        logger.log('getting vaults by profile Id', response.data)
        const vaults = response.data.map(pojo => new Vault(pojo))
        AppState.profileVaults = vaults
    }

}

export const vaultsService = new VaultsService()