// generated with @7nohe/openapi-react-query-codegen@1.4.1 

import { UseQueryResult } from "@tanstack/react-query";
import { AuthService, CubeService } from "../requests/services.gen";
export type AuthServiceGetApiV1AuthNonceDefaultResponse = Awaited<ReturnType<typeof AuthService.getApiV1AuthNonce>>;
export type AuthServiceGetApiV1AuthNonceQueryResult<TData = AuthServiceGetApiV1AuthNonceDefaultResponse, TError = unknown> = UseQueryResult<TData, TError>;
export const useAuthServiceGetApiV1AuthNonceKey = "AuthServiceGetApiV1AuthNonce";
export const UseAuthServiceGetApiV1AuthNonceKeyFn = (queryKey?: Array<unknown>) => [useAuthServiceGetApiV1AuthNonceKey, ...(queryKey ?? [])];
export type CubeServiceGetApiV1CubeByUserIdDefaultResponse = Awaited<ReturnType<typeof CubeService.getApiV1CubeByUserId>>;
export type CubeServiceGetApiV1CubeByUserIdQueryResult<TData = CubeServiceGetApiV1CubeByUserIdDefaultResponse, TError = unknown> = UseQueryResult<TData, TError>;
export const useCubeServiceGetApiV1CubeByUserIdKey = "CubeServiceGetApiV1CubeByUserId";
export const UseCubeServiceGetApiV1CubeByUserIdKeyFn = ({ userId }: {
  userId: string;
}, queryKey?: Array<unknown>) => [useCubeServiceGetApiV1CubeByUserIdKey, ...(queryKey ?? [{ userId }])];
export type AuthServicePostApiV1AuthLoginMutationResult = Awaited<ReturnType<typeof AuthService.postApiV1AuthLogin>>;
