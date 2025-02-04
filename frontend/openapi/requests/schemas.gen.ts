// This file is auto-generated by @hey-api/openapi-ts

export const $LoginRequest = {
    type: 'object',
    properties: {
        email: {
            type: 'string',
            nullable: true
        },
        password: {
            type: 'string',
            nullable: true
        },
        nonce: {
            type: 'string',
            format: 'uuid'
        }
    },
    additionalProperties: false
} as const;

export const $LoginResponse = {
    type: 'object',
    properties: {
        success: {
            type: 'boolean'
        }
    },
    additionalProperties: false
} as const;

export const $UserCubeModel = {
    type: 'object',
    properties: {
        cubeName: {
            type: 'string',
            nullable: true
        }
    },
    additionalProperties: false
} as const;