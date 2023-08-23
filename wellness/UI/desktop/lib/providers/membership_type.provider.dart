import '../models/membership_type.dart';
import 'base_provider.dart';

class MembershipTypeProvider extends BaseProvider<MembershipType> {
  MembershipTypeProvider() : super("MembershipType");

  @override
  MembershipType fromJson(data) {
    return MembershipType.fromJson(data);
  }
}
