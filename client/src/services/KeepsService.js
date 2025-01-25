import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { AppState } from "@/AppState.js"
import { Keep } from "@/models/Keep.js"

class KeepsService {
    setActiveKeep(keep) {
        AppState.activeKeep = keep
        logger.log('set active keep', AppState.activeKeep)
    }


    async getAllKeeps() {
        const response = await api.get('api/keeps')
        logger.log('got all keeps', response.data)
        AppState.keeps = response.data.map(pojo => new Keep(pojo))
    }

}



export const keepsService = new KeepsService()