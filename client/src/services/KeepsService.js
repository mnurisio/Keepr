import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { AppState } from "@/AppState.js"
import { Keep } from "@/models/Keep.js"

class KeepsService {

   async getProfileKeeps(profileId) {
    AppState.activeProfileKeeps = []
    const response = await api.get(`api/profiles/${profileId}/keeps`)
    logger.log('getting keeps by profile Id', response.data)
    const keeps = response.data.map(pojo => new Keep(pojo))
    AppState.activeProfileKeeps = keeps
    }
    async DeleteKeep(keepId) {
        const response = await api.delete(`api/keeps/${keepId}`)
        logger.log('deleting keep', response.data)
        const keepToDelete = AppState.keeps.findIndex(keep => keep.id == keepId)
        AppState.keeps.splice(keepToDelete, 1)
    }

    async createKeep(keepData) {
        const response = await api.post('api/keeps', keepData)
        logger.log('creating keep', response.data)
        const keep = new Keep(response.data)
        AppState.keeps.push(keep)
    }
    async getKeepById(keepId) {
        const response = await api.get(`api/keeps/${keepId}`)
        logger.log('got keep by Id', response.data)
        AppState.activeKeep = response.data
    }

    async IncrementKeeps(keepId, viewData) {
        const response = await api.put(`api/keeps/${keepId}`, viewData)
        AppState.activeKeep.views = response
    }


    setActiveKeep(keep) {
        AppState.activeKeep = keep

    }


    async getAllKeeps() {
        AppState.keeps = []
        const response = await api.get('api/keeps')
        logger.log('got all keeps', response.data)
        AppState.keeps = response.data.map(pojo => new Keep(pojo))
    }

}



export const keepsService = new KeepsService()