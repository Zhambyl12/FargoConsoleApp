//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace FargoParcelServiceTest1
//{
//    class Request
//    {
//        public static void SendRequest(string URL,string METHOD="get",string data = null, bool getToken = false)
//        {
//        string response = "";
//        bool isSuccess = false;

//            if (!getToken) {
//            $isTokenValid = $this->checkTokenExpired();
//                if (!$isTokenValid) {
//                $response['data']['code'] = 'error.validation';
//                $response['data']['message'] = __('Token Expired and cannot re-login to the System', 'wing');
//                    return $response;
//                }
//            }

//        $apiURL = $this->getAPIBaseURl();

//        $requestURL = $apiURL. $url;
//        $ch = curl_init($requestURL);

//            switch ($requestMethod) {
//            case 'get':
//                curl_setopt($ch, CURLOPT_CUSTOMREQUEST, 'GET');
//                break;
//            case 'post':
//                curl_setopt($ch, CURLOPT_CUSTOMREQUEST, 'POST');
//                break;
//            case 'put':
//                curl_setopt($ch, CURLOPT_CUSTOMREQUEST, 'PUT');
//                break;
//            case 'delete':
//                curl_setopt($ch, CURLOPT_CUSTOMREQUEST, 'DELETE');
//                break;
//            }

//        $json = $data? json_encode($data) : '';
//        $curlHeader = array(
//            'x-app-type: wordpress_plugin',
//            'Content-Type: application/json',
//            'Content-Length: '.strlen($json),
//            'RemoteAddr: '. $_SERVER['REMOTE_ADDR']
//        );

//            curl_setopt($ch, CURLOPT_POSTFIELDS, $json);

//        $token = $this->_merchantConfig['merchant_token'];

//            if (!$getToken) {
//                if ($token) {
//                $curlHeader[] = 'Authorization: '. 'Bearer '. $token;
//                $curlHeader[] = 'Accept: '. 'application/json';
//                } else
//                {
//                $curlHeader[] = 'Accept: '. '*/*';
//                }
//            } else
//            {
//            $curlHeader[] = 'Accept: '. '*/*';
//            }

//            curl_setopt($ch, CURLOPT_VERBOSE, 1);
//            curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, 0);
//            curl_setopt($ch, CURLOPT_SSL_VERIFYHOST, 0);
//            curl_setopt($ch, CURLOPT_HEADER, 0);
//            curl_setopt($ch, CURLINFO_HEADER_OUT, true);
//            curl_setopt($ch, CURLOPT_RETURNTRANSFER, TRUE);
//            curl_setopt($ch, CURLOPT_ENCODING, '');
//            curl_setopt($ch, CURLOPT_USERAGENT, $_SERVER['HTTP_USER_AGENT']);
//            curl_setopt($ch, CURLOPT_REFERER, $_SERVER['HTTP_HOST']. $_SERVER['REQUEST_URI']);
//            curl_setopt($ch, CURLOPT_HTTPHEADER, $curlHeader);
//            curl_setopt($ch, CURLOPT_TIMEOUT, 30);
//            curl_setopt($ch, CURLOPT_CONNECTTIMEOUT, 30);
//        $curl_response = curl_exec($ch);

//        $httpCode = curl_getinfo($ch, CURLINFO_HTTP_CODE);

//            if (curl_errno($ch))
//            {
//                shipox()->log->write(curl_error($ch), 'curl-error');
//                shipox()->log->write($json, 'curl-error');
//                shipox()->log->write($httpCode, 'curl-error');
//            }

//        $json_result = json_decode($curl_response, true);

//            shipox()->log->write($requestURL, 'curl-api');
//            shipox()->log->write($json, 'curl-api');
//            shipox()->log->write($httpCode, 'curl-api');
//            shipox()->log->write($curl_response, 'curl-api');
//            shipox()->log->write($json_result, 'curl-api');

//            switch (intval($httpCode))
//            {
//                case 200:
//                case 201:
//                $response['success'] = true;
//                    if ($json_result['status'] == 'success')
//                    $response['data'] = $json_result['data'];
//                else
//                    $response['data'] = $json_result;
//                    break;

//                default:
//                $response['data'] = $json_result;

//                    shipox()->log->write($requestURL, 'api-error');
//                    shipox()->log->write($json, 'api-error');
//                    shipox()->log->write($httpCode, 'api-error');
//                    shipox()->log->write($json_result, 'api-error');

//                    break;
//            }

//            return $response;
//        }

//        public static void checkTokenExpired()
//        {
//            if ((time() - $this->_merchantConfig['last_login_date']) > 100) {
//                if (is_null($this->_merchantConfig['merchant_username']) && is_null($this->_merchantConfig['merchant_password']))
//                {
//                    shipox()->log->write("Check Token Expired Function: Merchant option is empty", 'error');
//                    return false;
//                }

//            $time_request = time();
//            $response = $this->authenticate();

//                if ($response['success']) {
//                $options['merchant_token'] = $response['data']['id_token'];
//                $options['merchant_username'] = $this->_merchantConfig['merchant_username'];
//                $options['merchant_password'] = $this->_merchantConfig['merchant_password'];
//                $options['last_login_date'] = $time_request;

//                    update_option('wing_merchant_config', $options);

//                $this->init();

//                    shipox()->wing["api-helper"]->updateCustomerMarketplace();

//                    return true;
//                }

//                shipox()->log->write($response['data']['code']. ": ". $response['data']['message'], 'error');

//                return false;
//            }

//            return true;
//        }
//    }
//}
