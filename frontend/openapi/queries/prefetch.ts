// generated with @7nohe/openapi-react-query-codegen@1.4.1 

import { type QueryClient } from "@tanstack/react-query";
import { AuthService, CubeService } from "../requests/services.gen";
import * as Common from "./common";
export const prefetchUseAuthServiceGetApiV1AuthNonce = (queryClient: QueryClient) => queryClient.prefetchQuery({ queryKey: Common.UseAuthServiceGetApiV1AuthNonceKeyFn(), queryFn: () => AuthService.getApiV1AuthNonce() });
export const prefetchUseCubeServiceGetApiV1CubeByUserId = (queryClient: QueryClient, { userId }: {
  userId: string;
}) => queryClient.prefetchQuery({ queryKey: Common.UseCubeServiceGetApiV1CubeByUserIdKeyFn({ userId }), queryFn: () => CubeService.getApiV1CubeByUserId({ userId }) });
